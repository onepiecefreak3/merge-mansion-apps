using System;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Core;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.IO;
using Metaplay.UnityEngine;

namespace Metaplay.Metaplay.Unity.Localization
{
    public static class BuiltinLanguageRepository
    {
        private const string AppStartLanguageFile = "metaplay-lang-settings";
        private const int PersistedVersion = 2;

        //private static TaskQueueExecutor s_writeExecutor; // 0x0
        private static Dictionary<LanguageId, ContentHash> s_builtinLanguages; // 0x8

        public static void Initialize()
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                return;

            s_builtinLanguages = InternalGetBuiltinLanguages();
            //s_writeExecutor = new TaskQueueExecutor(TaskScheduler.Default);
        }

        public static Dictionary<LanguageId, ContentHash> GetBuiltinLanguages()
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                throw new NotSupportedException("BuiltinLanguageRepository requires EnableLocalizations feature to be enabled");

            return s_builtinLanguages;
        }

        public static LocalizationLanguage GetAppStartLocalization()
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                throw new NotSupportedException("BuiltinLanguageRepository requires EnableLocalizations feature to be enabled");

            var builtin = GetBuiltinLanguages();

            var path = Path.Combine(Application.PersistentDataPath, AppStartLanguageFile);
            var blob = AtomicBlobStore.TryReadBlob(path);

            LanguageId resultLang = null;
            if (blob != null)
            {
                if (!TryReadBlob(blob, out resultLang) || !builtin.ContainsKey(resultLang))
                {
                    AtomicBlobStore.TryDeleteBlob(path);
                    resultLang = null;
                }
            }

            if (resultLang == null)
            {
                var langMapping = IntegrationRegistry.Get<LanguageIdMapping>();
                var systemLang = langMapping.TryGetLanguageIdForDeviceLanguage(Application.SystemLanguage);
                if (systemLang != null && builtin.ContainsKey(systemLang))
                    resultLang = systemLang;
            }

            if (resultLang == null)
            {
                resultLang = MetaplayCore.Options.DefaultLanguage;
                StoreAppStartLanguage(resultLang);
            }

            var langPath = Path.Combine(Application.ApkPath, "Localizations", $"{resultLang.Value}.mpc");
            var langHash = builtin[resultLang];
            var langBlob = FileUtil.ReadAllBytes(langPath);

            return LocalizationLanguage.FromBytes(resultLang, langHash, langBlob, LocalizationStorageFormat.Binary);
        }

        public static async Task<LocalizationLanguage> GetLocalizationAsync(LanguageId language)
        {
            /* 	public int <>1__state; // 0x0
	            public AsyncTaskMethodBuilder<LocalizationLanguage> <>t__builder; // 0x8
	            public BuiltinLanguageRepository.<>c__DisplayClass4_0 <>4__this; // 0x20
	            private ContentHash <version>5__2; // 0x28
	            private TaskAwaiter<byte[]> <>u__1; // 0x38 */

            var builtin = GetBuiltinLanguages();
            if (!builtin.TryGetValue(language, out var version))
                throw new ArgumentException("invalid language, not a builtin");

            // Log debug "Accessing built-in localization for {Language}"

            var path = Path.Combine(Application.ApkPath, "Localizations", $"{language.Value}.mpc");
            var blob = await FileUtil.ReadAllBytesAsync(path);

            return LocalizationLanguage.FromBytes(language, version, blob, LocalizationStorageFormat.Binary);
        }

        public static void StoreAppStartLanguage(LanguageId language)
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                throw new NotSupportedException("BuiltinLanguageRepository requires EnableLocalizations feature to be enabled");

            var path = Path.Combine(Application.PersistentDataPath, AppStartLanguageFile);
            var blob = WriteBlob(language);

            // CUSTOM: Circumvent using the TaskQueueExecutor
            Task.Run(() => AtomicBlobStore.TryWriteBlob(path, blob));
        }

        public static LanguageId LanguageFilenameToLanguageName(string filename)
        {
            if (filename.Length <= 4 || !filename.EndsWith(".mpc"))
                throw new InvalidOperationException($"Invalid localization filename. Should end with .mpc but got \"{filename}\".");

            return LanguageId.FromString(filename[..^4]);
        }

        private static Dictionary<LanguageId, ContentHash> InternalGetBuiltinLanguages()
        {
            var result = new Dictionary<LanguageId, ContentHash>();

            var dir = Path.Combine(Application.ApkPath, "Localizations");
            var dirIndex = ConfigArchive.FolderEncoding.ReadDirectoryIndex(dir);

            foreach (var entry in dirIndex.FileEntries)
            {
                var entryName = Path.GetFileName(entry.Path);
                var langId = LanguageFilenameToLanguageName(entryName);

                result[langId] = entry.Version;
            }

            if (result.Count == 0)
                throw new InvalidOperationException($"The game build contains no localizations but EnableLocalizations=True is set in MetaplayCoreOptions. The build cannot launch from a clean state. Initial localizations must be built and included in the app StreamingAssets folder. The asset directory of localizations is {dir}");

            return result;
        }

        private static byte[] WriteBlob(LanguageId defaultAppStartLanguage)
        {
            using var writer = new IOWriter();

            writer.WriteInt32(PersistedVersion);
            writer.WriteString(defaultAppStartLanguage.Value);

            return writer.ConvertToStream().ToArray();
        }

        private static bool TryReadBlob(byte[] blob, out LanguageId defaultAppStartLanguage)
        {
            defaultAppStartLanguage = default;

            using var reader = new IOReader(blob);

            var version = reader.ReadInt32();
            if (version != PersistedVersion)
                return false;

            defaultAppStartLanguage = LanguageId.FromString(reader.ReadString(0x80));
            return true;
        }
    }
}
