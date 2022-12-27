using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Network;
using Metaplay.Metaplay.Core.Serialization;
using Metaplay.Metaplay.Network;

namespace Metaplay.Metaplay.Unity
{
    public sealed class MetaplayLocalizationManager
    {
        public readonly IMetaplayLocalizationDelegate Delegate; // 0x10

        private LocalizationManagerPersistedState _persisted; // 0x38
        private bool _persistedIsDirty; // 0x40
        private object _persistedIOLock; // 0x48
        private object _persistedEditLock; // 0x50
        private Dictionary<(LanguageId, ContentHash), DownloadStatusHistory> _downloadHistory; // 0x58
        private object _downloadHistoryLock; // 0x60
        private ISharedGameConfig _sessionGameConfig; // 0x68
        private Dictionary<LanguageId, ContentHash> _sessionLocalizationVersions; // 0x70
        private LocalizationStorageFormat _builtinFormat; // 0x78

        // 0x18
        public LanguageId ActiveLocalizationLanguage { get; set; }
        // 0x20
        public ContentHash ActiveLocalizationVersion { get; set; }
        // 0x30
        public Dictionary<LanguageId, LanguageStatus> Languages { get; set; }

        public bool IsAnyDownloadOngoing
        {
            get
            {
                lock (_downloadHistoryLock)
                {
                    foreach (var downloadHistory in _downloadHistory.Values)
                    {
                        if (downloadHistory.Status == LocalizationDownloadStatus.Downloading)
                            return true;
                    }

                    return false;
                }
            }
        }

        internal MetaplayLocalizationManager(IMetaplayLocalizationDelegate managerDelegate)
        {
            _persistedIOLock = new object();
            _persistedEditLock = new object();
            _downloadHistory = new Dictionary<(LanguageId, ContentHash), DownloadStatusHistory>();
            _downloadHistoryLock = new object();

            Delegate = managerDelegate;
        }

        internal void AfterSDKInit()
        {
            _builtinFormat = Delegate.BuiltinFormat;
            _persisted = ReadPersistentStateOrDefault(_builtinFormat, out _persistedIsDirty);

            LoadInitialLocalization();
            EditStateAndPersistIfDirtySync(null);
            UpdateLanguageStatuses();
        }

        internal void Start()
        {
            MetaplaySDK.MessageDispatcher.AddListener<UpdateLocalizationVersions>(OnUpdateLocalizationVersions);
        }

        private void OnUpdateLocalizationVersions(UpdateLocalizationVersions update)
        {
            _sessionLocalizationVersions = update.LocalizationVersions;
            UpdateLanguageStatuses();
        }

        internal void OnSessionStarted(SessionProtocol.SessionStartSuccess sessionStart)
        {
            var options = MetaplayCore.Options;
            if (!options.FeatureFlags.EnableLocalizations)
                return;

            var list = new List<(LanguageId, ContentHash)>();
            foreach (var downloadedLanguage in _persisted.DownloadedLanguages)
            {
                var locVersionFound = sessionStart.LocalizationVersions.TryGetValue(downloadedLanguage.Key, out var languageHash);

                foreach (var version in downloadedLanguage.Value.AllVersions)
                {
                    var builtinLang = _persisted.BuiltinLanguages.GetValueOrDefault(downloadedLanguage.Key, ContentHash.None);
                    if (version != builtinLang)
                    {
                        if (downloadedLanguage.Key == ActiveLocalizationLanguage)
                        {
                            if (version == ActiveLocalizationVersion)
                                continue;
                        }

                        if (locVersionFound && version == languageHash)
                            continue;
                    }

                    list.Add((downloadedLanguage.Key, version));
                }
            }

            foreach (var pair in list)
            {
                // Log info "Removing unused localization {pair.Item1}:{pair.Item2}"
                RemoveCachedLocalizationSync(pair.Item1, pair.Item2);
            }

            EditStateAndPersistIfDirtySync(null);
        }

        private void LoadInitialLocalization()
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
            {
                var noneLang = LanguageId.FromString("none");
                var dict = new Dictionary<TranslationId, string>();

                var lang = new LocalizationLanguage(noneLang, dict);

                MetaplaySDK.ActiveLanguage = lang;
                ActiveLocalizationLanguage = lang.LanguageId;
                ActiveLocalizationVersion = ContentHash.None;

                return;
            }

            if (_persisted.BuiltinLanguages.Count == 0)
                ; // Log error with MetaplaySDK.IncidentRepository "The game build contains no localizations but EnableLocalizations=True is set in MetaplayCoreOptions. The build cannot launch from a clean state. Initial localizations must be built and included in the app StreamingAssets folder. The asset directory of localizations is {MetaplaySDK.LocalizationsBuiltinPath}"

            if (_persisted.DefaultAppStartLanguage != null)
            {
                if (_persisted.DefaultAppStartLanguage == _persisted.MostRecentlyUsedLanguage)
                {
                    if (TryInitializeLocalizationWithLanguage(_persisted.MostRecentlyUsedLanguage, true, true, false, _persisted.MostRecentlyUsedVersion))
                        return;
                }

                if (TryInitializeLocalizationWithLanguage(_persisted.DefaultAppStartLanguage, true, false, false, null))
                    return;

                if (TryInitializeLocalizationWithLanguage(_persisted.DefaultAppStartLanguage, false, true, false, null))
                    return;

                _persisted.DefaultAppStartLanguage = null;
                _persistedIsDirty = true;
            }

            if (_persisted.MostRecentlyUsedLanguage != null)
            {
                if (TryInitializeLocalizationWithLanguage(_persisted.MostRecentlyUsedLanguage, true, true, false, _persisted.MostRecentlyUsedVersion))
                    return;

                _persisted.MostRecentlyUsedLanguage = null;
                _persistedIsDirty = true;
            }

            if (_persisted.MostRecentlyUsedLanguage != null)
            {
                if (TryInitializeLocalizationWithLanguage(_persisted.MostRecentlyUsedLanguage, true, false, false, null))
                    return;

                if (TryInitializeLocalizationWithLanguage(_persisted.MostRecentlyUsedLanguage, false, true, false, null))
                    return;

                _persisted.MostRecentlyUsedLanguage = null;
                _persistedIsDirty = true;
            }

            var set = new HashSet<LanguageId>(_persisted.BuiltinLanguages.Keys);
            var set1 = new HashSet<LanguageId>(_persisted.DownloadedLanguages.Keys);
            set1.UnionWith(set);

            var defLang = GetAppStartDefaultLanguage(set1);
            if (TryInitializeLocalizationWithLanguage(defLang, true, true, false, null))
                return;

            defLang = GetAppStartDefaultLanguage(set);
            if (TryInitializeLocalizationWithLanguage(defLang, false, true, true, null))
                return;

            // Log error with MetaplaySDK.IncidentRepository "Could not load any localization language in application start. EnableLocalizations=True in MetaplayCoreOptions requires that at least one localization must be available. See logs for details. The localizations asset directory is {MetaplaySDK.LocalizationsBuiltinPath} and the download cache directory is {MetaplaySDK.LocalizationsDownloadPath}"

            throw new InvalidOperationException("Could not load any localization language and application cannot start. See logs for details. If localization is not needed, they may be disabled by setting EnableLocalizations=False in MetaplayCoreOptions setup.");
        }

        private void UpdateLanguageStatuses()
        {
            var set = new HashSet<LanguageId>();
            lock (_persistedEditLock)
            {
                foreach (var key in _persisted.BuiltinLanguages.Keys)
                    set.Add(key);

                foreach (var key in _persisted.DownloadedLanguages.Keys)
                    set.Add(key);

                if (_sessionLocalizationVersions != null)
                    foreach (var key in _sessionLocalizationVersions.Keys)
                        set.Add(key);

                var dict = new Dictionary<LanguageId, LanguageStatus>();
                foreach (var element in set)
                {
                    if (_sessionGameConfig != null)
                    {
                        var languageInfo = _sessionGameConfig.TryGetLanguageInfo(element);
                        if (languageInfo == null)
                            continue;

                        // HINT: Following the code, languageInfo is never used after here.
                        // It's possible that TryGetLanguageInfo does some internal things, and we discard languageInfo, since we only want those internal changes
                    }

                    ContentHash? builtinHash = null;
                    if (_persisted.BuiltinLanguages.TryGetValue(element, out var builtinHash1))
                        builtinHash = builtinHash1;

                    ContentHash? latestDownloadHash = null;
                    ContentHash? latestVersionAvailable = null;
                    if (!_persisted.DownloadedLanguages.TryGetValue(element, out var languageState))
                    {
                        if (_sessionLocalizationVersions != null)
                            if (_sessionLocalizationVersions.TryGetValue(element, out var elementHash))
                                latestVersionAvailable = elementHash;
                    }
                    else
                    {
                        if (_sessionLocalizationVersions == null || !_sessionLocalizationVersions.TryGetValue(element, out var elementHash1))
                            latestDownloadHash = languageState.Latest;
                        else
                        {
                            latestDownloadHash = languageState.AllVersions.Contains(elementHash1)
                                ? elementHash1
                                : languageState.Latest;

                            if (_sessionLocalizationVersions != null)
                                if (_sessionLocalizationVersions.TryGetValue(element, out var elementHash))
                                    latestVersionAvailable = elementHash;
                        }
                    }

                    dict[element] = new LanguageStatus(element, builtinHash, latestDownloadHash, latestVersionAvailable);
                }

                Languages = dict;
            }

            AutoFlagsHandleDelegateOnLanguagesChanged();
            Delegate.OnLanguagesChanged();
        }

        private void AutoFlagsHandleDelegateOnLanguagesChanged()
        {
            if (Delegate.AutoFlags.HasFlag(LocalizationManagerAutoBehaviorFlag.DownloadActiveLanguageUpdates))
            {
                if (Languages.TryGetValue(ActiveLocalizationLanguage, out var languageStatus) && languageStatus.HasUpdateAvailable)
                {
                    var downloadHistory = GetDownloadStatusHistory(languageStatus.Language, languageStatus.LatestVersionAvailableForDownload.Value);
                    var shouldDownload = AutoFlagsShouldDownload(downloadHistory);
                    if (shouldDownload)
                        BeginFetchLanguage(languageStatus.Language, languageStatus.LatestVersionAvailableForDownload.Value, CancellationToken.None);
                }
            }

            if (Delegate.AutoFlags.HasFlag(LocalizationManagerAutoBehaviorFlag.HotUpdateActiveLanguageUpdates))
            {
                if (Languages.TryGetValue(ActiveLocalizationLanguage, out var languageStatus) && languageStatus.LatestVersionOnDevice.HasValue)
                {
                    if (ActiveLocalizationVersion == languageStatus.LatestVersionOnDevice.Value)
                        SetCurrentLanguage(ActiveLocalizationLanguage, languageStatus.LatestVersionOnDevice.Value, false);
                }
            }

            if (Delegate.AutoFlags.HasFlag(LocalizationManagerAutoBehaviorFlag.DownloadSomeVersionOfAllLanguages))
            {
                foreach (var lang in Languages.Values)
                {
                    if (lang.LatestVersionOnDevice.HasValue)
                        continue;

                    if (!lang.LatestVersionAvailableForDownload.HasValue)
                        continue;

                    if (IsAnyDownloadOngoing)
                        break;

                    var downloadHistory = GetDownloadStatusHistory(lang.Language, lang.LatestVersionAvailableForDownload.Value);
                    var shouldDownload = AutoFlagsShouldDownload(downloadHistory);
                    if (!shouldDownload)
                        continue;

                    BeginFetchLanguage(lang.Language, lang.LatestVersionAvailableForDownload.Value, CancellationToken.None);
                    break;
                }
            }
        }

        public DownloadStatusHistory GetDownloadStatusHistory(LanguageId language, ContentHash version)
        {
            lock (_downloadHistoryLock)
            {
                if (_downloadHistory.TryGetValue((language, version), out var statusHistory))
                    return statusHistory;

                return new DownloadStatusHistory(LocalizationDownloadStatus.NotDownloaded);
            }
        }

        private static bool AutoFlagsShouldDownload(DownloadStatusHistory statusHistory)
        {
            if (statusHistory.Status != LocalizationDownloadStatus.DownloadFailed)
                return statusHistory.Status == LocalizationDownloadStatus.NotDownloaded;

            var delta = MetaTime.Now - statusHistory.Since;
            return delta > MetaDuration.FromMinutes(5);
        }

        public void SetCurrentLanguage(LanguageId language, ContentHash version, bool setAsAppStartLanguage = true)
        {
            throw new NotImplementedException();
        }

        private bool TryInitializeLocalizationWithLanguage(LanguageId language, bool allowUseDownloaded, bool allowUseBuiltin, bool isLastResort, ContentHash? versionRequirement)
        {
            if (allowUseDownloaded)
            {
                if (_persisted.DownloadedLanguages.TryGetValue(language, out var downloadState))
                {
                    if (downloadState.AllVersions.Count - 1 > -1)
                    {
                        for (var i = downloadState.AllVersions.Count - 1; i >= 0; i--)
                        {
                            var version = downloadState.AllVersions[i];
                            if (versionRequirement.HasValue && versionRequirement.Value != version)
                                continue;

                            if (TryInitializeLocalizationWithLanguageVersion(language, version, true, isLastResort))
                                return true;

                            // Log warning with MetaplaySDK.IncidentRepository "Could not load latest downloaded language {language.Value}:{version}. Removing."
                            RemoveCachedLocalizationSync(language, downloadState.Latest);
                        }
                    }
                }
            }

            if (allowUseBuiltin)
            {
                if (_persisted.BuiltinLanguages.TryGetValue(language, out var langHash))
                {
                    if (versionRequirement.HasValue && versionRequirement.Value != langHash)
                        return false;

                    if (TryInitializeLocalizationWithLanguageVersion(language, langHash, false, isLastResort))
                        return true;
                }
            }

            return false;
        }

        private bool TryInitializeLocalizationWithLanguageVersion(LanguageId language, ContentHash version, bool fromDownloaded, bool isLastResort)
        {
            var lang = TryLoadLocalizationMainThreadSync(language, version, fromDownloaded);
            if (lang != null)
                return TryActivateInitialLocalization(language, version, lang, isLastResort);

            return false;
        }

        private bool TryActivateInitialLocalization(LanguageId language, ContentHash version, LocalizationLanguage localization, bool isLastResort)
        {
            if (!ValidateLocalization(localization, out var validateEx))
            {
                if (!isLastResort)
                    return false;

                // Log warning with MetaplaySDK.IncidentRepository "All languages failed validation check. Using last resort {language.Value}:{version}."
            }

            MetaplaySDK.ActiveLanguage = localization;
            ActiveLocalizationLanguage = language;
            ActiveLocalizationVersion = version;

            Delegate.OnActiveLanguageChanged();

            return true;
        }

        private LanguageId GetAppStartDefaultLanguage(HashSet<LanguageId> languages)
        {
            var langId = Delegate.GetAppStartDefaultLanguage(languages);
            if (languages.Contains(langId))
                return langId;

            // Log debug with MetaplaySDK.IncidentRepository "Choosing language automatically."

            if (languages.Count == 0)
                return null;

            return new List<LanguageId>(languages)[0];
        }

        private static LocalizationManagerPersistedState ReadPersistentStateOrDefault(LocalizationStorageFormat builtinFormat, out bool stateIsDirty)
        {
            var flags = MetaplayCore.Options.FeatureFlags;
            if (!flags.EnableLocalizations)
            {
                stateIsDirty = false;
                return CreateDefaultDisabledState();
            }

            var state = TryReadPersistentState();
            stateIsDirty = state == null;
            state ??= CreateInitialState();

            state.BuiltinLanguages = ScanBuiltinLanguages(builtinFormat);
            return state;
        }

        private static LocalizationManagerPersistedState CreateDefaultDisabledState()
        {
            return new LocalizationManagerPersistedState();
        }

        private static LocalizationManagerPersistedState TryReadPersistentState()
        {
            var persistentStatePath = GetPersistentStatePath();
            var blob = AtomicBlobStore.TryReadBlob(persistentStatePath);

            if (blob == null)
                return null;

            var state = MetaSerialization.DeserializeTagged<LocalizationManagerPersistedState>(blob, MetaSerializationFlags.IncludeAll, null, null, null);
            if (!state.IsValid())
                return null;

            return state;
        }

        private static LocalizationManagerPersistedState CreateInitialState()
        {
            var state = new LocalizationManagerPersistedState();
            var dict = new Dictionary<LanguageId, DownloadedLanguageState>();

            state.DownloadedLanguages = dict;

            Directory.CreateDirectory(MetaplaySDK.LocalizationsDownloadPath);

            var dirs = Directory.GetDirectories(MetaplaySDK.LocalizationsDownloadPath);
            for (var i = 0; i < dirs.Length; i++)
            {
                var dirName = Path.GetFileName(dirs[i]);
                if (!TryGetLanguageFromFileName(dirName, LocalizationStorageFormat.Binary, out var lang))
                    continue;

                var downloadState = new DownloadedLanguageState();
                var files = Directory.GetFiles(dirs[i]);
                for (var j = 0; j < files.Length; j++)
                {
                    var fileName = Path.GetFileName(files[j]);
                    var fileNameHash = ContentHash.ParseString(fileName);

                    if (fileNameHash != ContentHash.None)
                    {
                        downloadState.AllVersions.Add(fileNameHash);
                        downloadState.Latest = fileNameHash;
                    }
                }

                if (downloadState.AllVersions.Count > 0)
                    state.DownloadedLanguages.Add(lang, downloadState);
            }

            return state;
        }

        private static bool TryGetLanguageFromFileName(string filename, LocalizationStorageFormat format, out LanguageId language)
        {
            language = null;
            if (filename.Length < 4)
                return false;

            var ext = format == LocalizationStorageFormat.LegacyCsv ? ".csv" : ".mpc";
            if (!filename.EndsWith(ext))
                return false;

            language = LanguageId.FromString(filename.Substring(0, filename.Length - 4));
            return true;
        }

        private static Dictionary<LanguageId, ContentHash> ScanBuiltinLanguages(LocalizationStorageFormat builtinFormat)
        {
            var res = new Dictionary<LanguageId, ContentHash>();
            var dirIndex = ConfigArchive.FolderEncoding.ReadDirectoryIndex(MetaplaySDK.LocalizationsBuiltinPath);
            foreach (var index in dirIndex.FileEntries)
            {
                var indexFileName = Path.GetFileName(index.Path);
                if (TryGetLanguageFromFileName(indexFileName, builtinFormat, out var indexLang))
                    res[indexLang] = index.Version;
            }

            return res;
        }

        public LocalizationDownload BeginFetchLanguage(LanguageId language, ContentHash version, CancellationToken ct)
        {
            var sameLangHash = false;
            var containsLang = false;
            lock (_persistedEditLock)
            {
                if (_persisted.BuiltinLanguages.TryGetValue(language, out var langHash))
                    sameLangHash = version == langHash;

                if (_persisted.DownloadedLanguages.TryGetValue(language, out var langState))
                    containsLang = langState.AllVersions.Contains(version);
            }

            var loc = TryLoadLocalizationMainThreadSync(language, version, false);
            if (!sameLangHash || loc == null)
            {
                if (!containsLang)
                    return LocalizationDownload.CreateDownload(language, version, ct);

                loc = TryLoadLocalizationMainThreadSync(language, version, true);
                if (loc == null)
                {
                    // Log warning "Could not load downloaded language {language.Value}:{version}. Removing.

                    EditStateAndPersistIfDirtySync(state => RemoveCachedLocalizationSync(language, version));
                    return LocalizationDownload.CreateDownload(language, version, ct);
                }
            }

            return LocalizationDownload.CreateExisting(language, version, true, loc);
        }

        private LocalizationLanguage TryLoadLocalizationMainThreadSync(LanguageId language, ContentHash version, bool fromDownloaded)
        {
            if (fromDownloaded)
                return LocalizationLanguage.FromBytes(language, File.ReadAllBytes(GetDownloadedLocalizationFullPath(language, version)), LocalizationStorageFormat.Binary);

            return LocalizationLanguage.FromBytes(language, FileUtil.ReadAllBytes(GetBuiltinLocalizationFullPath(language)), _builtinFormat);
        }

        private string GetBuiltinLocalizationFullPath(LanguageId language)
        {
            return Path.Combine(MetaplaySDK.LocalizationsBuiltinPath, GetBuiltinLocalizationFileName(language));
        }

        private string GetBuiltinLocalizationFileName(LanguageId language)
        {
            return string.Concat(language.Value, '.', _builtinFormat != LocalizationStorageFormat.Binary ? "csv" : "mpc");
        }

        private void SetDownloadAsActive(LocalizationDownload download)
        {
            var locLang = download.GetResult();
            var isValid = ValidateLocalization(locLang, out var validateEx);
            if (!isValid)
            {
                if (validateEx == null)
                    throw new InvalidOperationException("download validation failed");

                // Log warning: Could not load downloaded language {download.Language}:{download.Version}. Removing.
                EditStateAndPersistIfDirtySync(state => RemoveCachedLocalizationSync(download.Language, download.Version));
            }

            var isUpdate = UpdateActiveLanguage(download.Language, download.Version, locLang, out var delegateEx);
        }

        private bool ValidateLocalization(LocalizationLanguage localization, out Exception validationException)
        {
            validationException = null;
            return Delegate.ValidateLanguage(localization);
        }

        private void RemoveCachedLocalizationSync(LanguageId language, ContentHash version)
        {
            var downloadedLanguages = _persisted.DownloadedLanguages;
            if (!downloadedLanguages.TryGetValue(language, out var state))
                return;

            var isRemoved = state.AllVersions.Remove(version);
            if (!isRemoved)
                return;

            TryDeleteDownloadedLocalization(language, version);
            if (state.AllVersions.Count - 1 < 0)
                _persisted.DownloadedLanguages.Remove(language);
            else
                state.Latest = state.AllVersions[^1];

            _persistedIsDirty = true;
        }

        private void TryDeleteDownloadedLocalization(LanguageId language, ContentHash version)
        {
            var path = GetDownloadedLocalizationFullPath(language, version);
            File.Delete(path);
        }

        private bool UpdateActiveLanguage(LanguageId language, ContentHash version, LocalizationLanguage localization, out Exception delegateException)
        {
            MetaplaySDK.ActiveLanguage = localization;

            ActiveLocalizationLanguage = language;
            ActiveLocalizationVersion = version;

            Delegate.OnActiveLanguageChanged();

            EditStateAndPersistIfDirtySync(state =>
            {
                if (state.MostRecentlyUsedLanguage == language)
                    if (state.MostRecentlyUsedVersion == version)
                        return;

                state.MostRecentlyUsedLanguage = language;
                state.MostRecentlyUsedVersion = version;
                _persistedIsDirty = true;
            });

            delegateException = null;
            return true;
        }

        private async Task<LocalizationLanguage> DownloadAndPutToCacheAsync(LanguageId language, ContentHash version, int numFetchAttempts, TimeSpan fetchTimeout, CancellationToken ct)
        {
            // Log Debug: Starting CDN fetch of {language.Value} : {version}

            lock (_downloadHistoryLock)
            {
                _downloadHistory[(language, version)] = new DownloadStatusHistory(LocalizationDownloadStatus.Downloading);
            }

            await Task.Delay(fetchTimeout, ct);
            var locLang = await DoDownloadAndPutToCacheAsync(language, version);

            ct.ThrowIfCancellationRequested();

            return locLang;
        }

        private async Task<LocalizationLanguage> DoDownloadAndPutToCacheAsync(LanguageId language, ContentHash version)
        {
            // Prepare download
            var diskStorage = new DiskBlobStorage(MetaplaySDK.LocalizationsDownloadPath);
            var subDir = MetaplaySDK.CdnAddress.GetSubdirectoryAddress("GameConfig").GetSubdirectoryAddress("Localizations");

            var httpProvider = new HttpBlobProvider(MetaHttpClient.DefaultInstance, subDir, null);
            var langFileName = GetDownloadedLocalizationFileName(language);

            // Download language data
            var langData = await httpProvider.GetAsync(langFileName, version);

            // Parse language data
            var parsedLang = LocalizationLanguage.FromBytes(language, langData, LocalizationStorageFormat.Binary);

            // Put language data to disk for loading it up later
            var relPath = GetDownloadedLocalizationRelativePath(language, version);
            var putResult = await diskStorage.PutAsync(relPath, langData, new BlobStoragePutHints());

            if (!putResult)
                throw new IOException("could not write localization to cache");

            EditStateAndPersistIfDirtySync(state =>
            {
                if (!_persisted.DownloadedLanguages.TryGetValue(language, out var langState))
                {
                    langState = new DownloadedLanguageState();
                    _persisted.DownloadedLanguages.Add(language, langState);
                    _persistedIsDirty = true;
                }

                if (langState.AllVersions.Contains(version))
                    return;

                langState.AllVersions.Add(version);
                langState.Latest = version;
                _persistedIsDirty = true;
            });

            lock (_downloadHistoryLock)
            {
                _downloadHistory[(language, version)] = new DownloadStatusHistory(LocalizationDownloadStatus.DownloadComplete);
            }

            return parsedLang;
        }

        // TODO: Write serialized data
        private void EditStateAndPersistIfDirtySync(Action<LocalizationManagerPersistedState> editFn)
        {
            lock (_persistedIOLock)
            {
                byte[] serialized = null;
                var st = 4;
                lock (_persistedEditLock)
                {
                    editFn?.Invoke(_persisted);
                    if (_persistedIsDirty)
                    {
                        serialized = MetaSerialization.SerializeTagged(_persisted, MetaSerializationFlags.IncludeAll, null, null);
                        st = 5;
                    }
                }

                if (st == 5)
                {
                    if (MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                    {
                        var path = GetPersistentStatePath();
                        var isWritten = AtomicBlobStore.TryWriteBlob(path, serialized);
                        if (isWritten)
                            return;
                    }

                    _persistedIsDirty = false;
                }
            }
        }

        private static string GetDownloadedLocalizationFileName(LanguageId language)
        {
            return string.Concat(language.Value, ".mpc");
        }

        private static string GetDownloadedLocalizationRelativePath(LanguageId language, ContentHash version)
        {
            var locName = GetDownloadedLocalizationFileName(language);

            return Path.Combine(locName, version.ToString());
        }

        private static string GetDownloadedLocalizationFullPath(LanguageId language, ContentHash version)
        {
            var locPath = MetaplaySDK.LocalizationsDownloadPath;
            var locName = GetDownloadedLocalizationFileName(language);

            return Path.Combine(locPath, locName, version.ToString());
        }

        private static string GetPersistentStatePath()
        {
            return Path.Combine(MetaplaySDK.LocalizationsDownloadPath, "MetaplayPersistedState.dat");
        }

        public struct DownloadStatusHistory
        {
            public readonly LocalizationDownloadStatus Status; // 0x0
            public readonly MetaTime Since; // 0x8

            public DownloadStatusHistory(LocalizationDownloadStatus status)
            {
                Status = status;
                Since = MetaTime.Now;
            }
        }

        public readonly struct LanguageStatus
        {
            public readonly LanguageId Language; // 0x0
            public readonly ContentHash? BuiltinVersion; // 0x8
            public readonly ContentHash? LatestDownloadedVersion; // 0x20
            public readonly ContentHash? LatestVersionAvailableForDownload; // 0x38

            public ContentHash? LatestVersionOnDevice => LatestDownloadedVersion ?? BuiltinVersion;
            public bool HasUpdateAvailable
            {
                get
                {
                    if (!LatestVersionAvailableForDownload.HasValue)
                        return false;

                    if (LatestDownloadedVersion.HasValue &&
                        LatestDownloadedVersion.Value == LatestVersionAvailableForDownload.Value)
                        return false;

                    if (BuiltinVersion.HasValue &&
                        BuiltinVersion.Value == LatestVersionAvailableForDownload.Value)
                        return false;

                    return true;
                }
            }

            public LanguageStatus(LanguageId language, ContentHash? builtinVersion, ContentHash? latestDownloadedVersion, ContentHash? latestVersionAvailableForDownload)
            {
                Language = language;
                BuiltinVersion = builtinVersion;
                LatestDownloadedVersion = latestDownloadedVersion;
                LatestVersionAvailableForDownload = latestVersionAvailableForDownload;
            }
        }

        public enum LocalizationDownloadStatus
        {
            NotDownloaded = 0,
            Downloading = 1,
            DownloadFailed = 2,
            DownloadComplete = 3
        }

        public class LocalizationManagerPersistedState
        {
            [MetaMember(1, 0)]
            public int Version; // 0x10
            [MetaMember(2, 0)]
            public LanguageId DefaultAppStartLanguage; // 0x18
            [MetaMember(3, 0)]
            public LanguageId MostRecentlyUsedLanguage; // 0x20
            [MetaMember(4, 0)]
            public ContentHash MostRecentlyUsedVersion; // 0x28
            public Dictionary<LanguageId, ContentHash> BuiltinLanguages; // 0x38
            [MetaMember(6, 0)]
            public Dictionary<LanguageId, DownloadedLanguageState> DownloadedLanguages; // 0x40

            public LocalizationManagerPersistedState()
            {
                Version = 1;
                BuiltinLanguages = new Dictionary<LanguageId, ContentHash>();
                DownloadedLanguages = new Dictionary<LanguageId, DownloadedLanguageState>();
            }

            public bool IsValid()
            {
                if (Version != 1 || BuiltinLanguages == null || DownloadedLanguages == null)
                    return false;

                foreach (var v in DownloadedLanguages.Values)
                    if (!v.IsValid())
                        return false;

                return true;
            }
        }

        public class DownloadedLanguageState
        {
            [MetaMember(1, 0)]
            public ContentHash Latest; // 0x10
            [MetaMember(2, 0)]
            public List<ContentHash> AllVersions; // 0x20

            public DownloadedLanguageState()
            {
                AllVersions = new List<ContentHash>();
            }

            public bool IsValid()
            {
                if (AllVersions == null || AllVersions.Count == 0)
                    return false;

                return AllVersions[^1] == Latest;
            }
        }

        public class LocalizationDownload : IDownload
        {
            // Fields
            public readonly LanguageId Language; // 0x10
            public readonly ContentHash Version; // 0x18
            public readonly bool IsBuiltin; // 0x28
            private DownloadTaskWrapper<LocalizationLanguage> _download; // 0x30

            public DownloadStatus Status => _download.Status;

            private LocalizationDownload(LanguageId language, ContentHash version, bool isBuiltin, LocalizationLanguage alreadyComputedResult)
            {
                Language = language;
                Version = version;
                IsBuiltin = isBuiltin;
                _download = new DownloadTaskWrapper<LocalizationLanguage>(Task.FromResult(alreadyComputedResult));
            }

            private LocalizationDownload(LanguageId language, ContentHash version, TimeSpan fetchTimeout, int fetchAttemptMaxCount, CancellationToken ct)
            {
                Language = language;
                Version = version;
                IsBuiltin = false;
                _download = new DownloadTaskWrapper<LocalizationLanguage>(MetaplaySDK.LocalizationManager.DownloadAndPutToCacheAsync(language, version, fetchAttemptMaxCount, fetchTimeout, ct));
            }

            public static LocalizationDownload CreateExisting(LanguageId language, ContentHash version, bool fromDownloaded, LocalizationLanguage localization)
            {
                return new LocalizationDownload(language, version, !fromDownloaded, localization);
            }

            public static LocalizationDownload CreateDownload(LanguageId language, ContentHash version, CancellationToken ct)
            {
                var timeoutSpan = MetaplaySDK.Connection.Config.ConfigFetchTimeout.ToTimeSpan();
                var fetchAttemptsMax = MetaplaySDK.Connection.Config.ConfigFetchAttemptsMaxCount;

                return new LocalizationDownload(language, version, timeoutSpan, fetchAttemptsMax, ct);
            }

            public LocalizationLanguage GetResult()
            {
                if (Status.Code != DownloadStatus.StatusCode.Completed)
                    throw new InvalidOperationException("invalid state, not completed");

                return _download.GetResult();
            }

            public void SetAsActiveLocalization()
            {
                if (Status.Code != DownloadStatus.StatusCode.Completed)
                    throw new InvalidOperationException("invalid state, not completed");

                MetaplaySDK.LocalizationManager.SetDownloadAsActive(this);
            }

            public void Dispose()
            {
                _download.Dispose();
            }
        }
    }
}
