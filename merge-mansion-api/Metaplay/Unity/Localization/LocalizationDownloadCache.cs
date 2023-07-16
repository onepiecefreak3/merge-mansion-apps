using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Network;
using Metaplay.Metaplay.Core;
using System.Threading.Tasks;
using System.Threading;
using Metaplay.Metaplay.Core.Config;
using Metaplay.UnityEngine;

namespace Metaplay.Metaplay.Unity.Localization
{
    public class LocalizationDownloadCache
    {
        //private LogChannel _log; // 0x10
        private string _downloadDir; // 0x18
        private object _lock; // 0x20
        private Dictionary<LanguageId, LanguageLocalizationFiles> _cached; // 0x28
        private uint _lastTimestamp; // 0x30
        private Task _initTask; // 0x38

        public LocalizationDownloadCache()
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                throw new NotSupportedException("LocalizationDownloadCache requires EnableLocalizations feature to be enabled");

            _downloadDir = Path.Combine(Application.TemporaryCachePath, "Localizations");
            _lock = new object();

            _initTask = Task.Run(async () =>
            {
                await InitializeAsync();
            });
        }

        internal void Start()
        {
            MetaplaySDK.MessageDispatcher.AddListener<SessionProtocol.SessionStartSuccess>(OnSessionStart);
            MetaplaySDK.MessageDispatcher.AddListener<UpdateLocalizationVersions>(OnUpdateLocalizationVersions);
        }

        internal void Stop()
        {
            MetaplaySDK.MessageDispatcher.RemoveListener<SessionProtocol.SessionStartSuccess>(OnSessionStart);
            MetaplaySDK.MessageDispatcher.RemoveListener<UpdateLocalizationVersions>(OnUpdateLocalizationVersions);
        }

        private async Task InitializeAsync()
        {
            var files = await DirectoryUtil.GetDirectoryAndSubdirectoryFilesAsync(_downloadDir);
            Array.Sort(files, StringComparer.InvariantCulture);

            var builtins = BuiltinLanguageRepository.GetBuiltinLanguages();
            var languageFiles = new Dictionary<LanguageId, List<string>>();
            var cached = new Dictionary<LanguageId, LanguageLocalizationFiles>();

            for (var i = 0; i < files.Length; i++)
            {
                var subPath = files[i][(_downloadDir.Length + 1)..];
                if (!ShouldKeepCached(subPath, builtins, out var lang, out var timeStamp, out var version))
                {
                    // Log debug "DLCache: Removing unrecognized entry: {Path}"
                    await FileUtil.DeleteAsync(files[i]);

                    continue;
                }

                if (!cached.ContainsKey(lang))
                    cached[lang] = new LanguageLocalizationFiles();

                var timeStamps = cached[lang].GetTimestampsForVersion(version);
                if (timeStamps.Length != 0)
                {
                    // Log debug "DLCache: Removing duplicate entry: {Path}"
                    await FileUtil.DeleteAsync(files[i]);

                    continue;
                }

                cached[lang].AddEntry(version, timeStamp);
                if (!languageFiles.ContainsKey(lang))
                    languageFiles[lang] = new List<string>();

                languageFiles[lang].Add(files[i]);
                // Log debug "DLCache: Found entry for {Language} - {Version}."
            }

            foreach (var (langId, langFiles) in languageFiles)
            {
                if (files.Length < 10)
                    continue;

                // Log debug "DLCache: Too many cached version for {Language}, removing all."
                cached.Remove(langId);

                foreach (var langFile in langFiles)
                    await FileUtil.DeleteAsync(langFile);
            }

            // Log debug "DLCache initialization complete."
            lock (_lock)
                _cached = cached;
        }

        private static bool ShouldKeepCached(string subpath, Dictionary<LanguageId, ContentHash> builtins,
            out LanguageId language, out uint timestamp, out ContentHash version)
        {
            language = null;
            version = ContentHash.None;
            timestamp = 0;

            var pathParts = subpath.Split('/');
            if (pathParts[0].Length <= 4 || !pathParts[0].EndsWith(".mpc"))
                return false;

            var fileLang = LanguageId.FromString(pathParts[0][..^4]);
            if (!builtins.ContainsKey(fileLang))
                return false;

            var subPath1 = subpath[(pathParts[0].Length + 1)..];
            timestamp = Convert.ToUInt32(subPath1[..8], 16);
            if (!ContentHash.TryParseString(subPath1[9..], out version))
                return false;

            if (builtins[fileLang] == version)
                return false;

            language = fileLang;
            return true;
        }

        private string GetDownloadedLocalizationPath(LanguageId language, uint timestamp, ContentHash version)
        {
            return Path.Combine(_downloadDir, $"{language}.mpc", $"{timestamp:X8}-{version}");
        }

        public async Task<LocalizationLanguage> GetLocalizationAsync(LanguageId language, ContentHash version,
            MetaplayCdnAddress cdnAddress, int numFetchAttempts, MetaDuration fetchTimeout, CancellationToken ct)
        {
            await _initTask;

            var timestamps = Array.Empty<uint>();
            lock (_lock)
            {
                if (_cached.TryGetValue(language, out var locFiles))
                    timestamps = locFiles.GetTimestampsForVersion(version);
            }

            if (timestamps.Length != 0)
            {
                var pathInCache = GetDownloadedLocalizationPath(language, timestamps[0], version);
                // Log debug "Serving localization fetch of {Language} : {ConfigVersion} from cache"

                var fileContent = await FileUtil.ReadAllBytesAsync(pathInCache);
                return LocalizationLanguage.FromBytes(language, version, fileContent, LocalizationStorageFormat.Binary);
            }

            // Log debug "Starting CDN fetch of localization {Language} : {ConfigVersion}"
            var retryNdx = 0;

            var wait = Task.Delay(fetchTimeout.ToTimeSpan(), ct);
            var fetchTask = DownloadAndPutToCacheAsync(language, version, cdnAddress);
        Retry:
            var anyTask = await Task.WhenAny(fetchTask, wait);

            ct.ThrowIfCancellationRequested();

            switch (fetchTask.Status)
            {
                case TaskStatus.Faulted:
                    if (retryNdx >= numFetchAttempts && numFetchAttempts != -1)
                        throw fetchTask.Exception?.InnerException; // Log warning "Localization fetching failed, will not retry anymore: {fetchTask.Exception.InnerException}"

                    retryNdx++;
                    // Log debug "Localization fetching failed, will retry (retryno={retryNdx}): {fetchTask.Exception.InnerException}"

                    goto Retry;

                case TaskStatus.RanToCompletion:
                    return fetchTask.Result;

                default:
                    throw new TimeoutException();
            }
        }

        private async Task<LocalizationLanguage> DownloadAndPutToCacheAsync(LanguageId language, ContentHash version, MetaplayCdnAddress cdnAddress)
        {
            cdnAddress = cdnAddress.GetSubdirectoryAddress("GameConfig").GetSubdirectoryAddress("Localizations");

            var blobProvider = new HttpBlobProvider(MetaHttpClient.DefaultInstance, cdnAddress, null);
            var bytes = await blobProvider.GetAsync($"{language}.mpc", version);

            var localization = LocalizationLanguage.FromBytes(language, version, bytes, LocalizationStorageFormat.Binary);

            uint timestamp;
            lock (_lock)
            {
                timestamp = (uint)(MetaTime.Now.MillisecondsSinceEpoch / 1000);
                _lastTimestamp = Math.Max(_lastTimestamp + 1, timestamp);
            }

            var pathInCache = GetDownloadedLocalizationPath(language, _lastTimestamp, version);
            await DirectoryUtil.EnsureDirectoryExistsAsync(Path.GetDirectoryName(pathInCache));

            await FileUtil.WriteAllBytesAtomicAsync(pathInCache, bytes);

            lock (_lock)
            {
                if (!_cached.ContainsKey(language))
                    _cached[language] = new LanguageLocalizationFiles();

                _cached[language].AddEntry(version, timestamp);
            }

            return localization;
        }

        private void OnSessionStart(SessionProtocol.SessionStartSuccess sessionStart)
        {
            PruneOldLocalizationsInBackground(sessionStart.LocalizationVersions);
        }

        private void OnUpdateLocalizationVersions(UpdateLocalizationVersions update)
        {
            PruneOldLocalizationsInBackground(update.LocalizationVersions);
        }

        private void PruneOldLocalizationsInBackground(Dictionary<LanguageId, ContentHash> latestLocalizations)
        {
            var versionsToDelete = new List<(LanguageId, uint, ContentHash)>();
            lock (_lock)
            {
                if (_cached == null)
                    return;

                foreach (var (languageId, locFiles) in _cached)
                {
                    var versions = locFiles.GetVersions();
                    if (versions.Length <= 0)
                        continue;

                    foreach (ContentHash version in versions)
                    {
                        if (latestLocalizations.ContainsKey(languageId))
                            if (latestLocalizations[languageId] == version)
                                continue;

                        var timestamps = locFiles.GetTimestampsForVersion(version);
                        if (timestamps.Length <= 0)
                            continue;

                        foreach (uint timestamp in timestamps)
                            versionsToDelete.Add((languageId, timestamp, version));
                    }
                }

                foreach (var versionToDelete in versionsToDelete)
                {
                    _cached[versionToDelete.Item1].RemoveEntry(versionToDelete.Item3, versionToDelete.Item2);
                    if (_cached[versionToDelete.Item1].NumFiles == 0)
                        _cached.Remove(versionToDelete.Item1);
                }

                Task.Run(async () =>
                {
                    foreach (var versionToDelete in versionsToDelete)
                    {
                        var deletePath = GetDownloadedLocalizationPath(versionToDelete.Item1, versionToDelete.Item2, versionToDelete.Item3);
                        // Log debug "DLCache: Removing pruned old entry: {deletePath}"

                        await FileUtil.DeleteAsync(deletePath);
                    }
                });
            }
        }

        private class LanguageLocalizationFiles
        {
            private readonly HashSet<(ContentHash, uint)> _versionTimestamps; // 0x10

            public int NumFiles => _versionTimestamps.Count;

            public LanguageLocalizationFiles()
            {
                _versionTimestamps = new HashSet<(ContentHash, uint)>();
            }

            public void AddEntry(ContentHash version, uint timestamp)
            {
                _versionTimestamps.Add((version, timestamp));
            }

            public void RemoveEntry(ContentHash version, uint timestamp)
            {
                _versionTimestamps.Remove((version, timestamp));
            }

            public ContentHash[] GetVersions()
            {
                var timestamps = new HashSet<ContentHash>();
                foreach (var timestamp in _versionTimestamps)
                    timestamps.Add(timestamp.Item1);

                return timestamps.ToArray();
            }

            public uint[] GetTimestampsForVersion(ContentHash version)
            {
                var timestamps = new HashSet<uint>();
                foreach (var timestamp in _versionTimestamps)
                    if (timestamp.Item1 == version)
                        timestamps.Add(timestamp.Item2);

                return timestamps.ToArray();
            }
        }
    }
}
