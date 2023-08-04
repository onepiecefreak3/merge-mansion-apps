using System.Collections.Generic;
using System.IO;

namespace UnityEngine
{
    // UnityEngine.Application
    public static class Application
    {
        // CUSTOM: Versions and identifiers for each region the application can run in
        private static readonly IDictionary<SystemLanguage, string> Versions = new Dictionary<SystemLanguage, string>();
        private static readonly IDictionary<SystemLanguage, string> Identifiers = new Dictionary<SystemLanguage, string>();

        #region Paths

        // CUSTOM: The root for all relative path properties
        private static string Root { get; set; } = ".\\resources";

        // CUSTOM: To access downloaded assets and resources
        public static string DataPath => Path.Combine(Root, "data", Identifier);

        // CUSTOM: To access data in the accessible storage of the user (eg. /storage/emulated/0/Android/[...])
        public static string PersistentDataPath => Path.Combine(Root, "user", "data", Identifier, "files");

        // CUSTOM: To access assets from the APK
        public static string ApkPath => Path.Combine(Root, "apk");

        // CUSTOM: To access and write temporary data of the user
        public static string TemporaryCachePath => Path.Combine(DataPath, "cache");

        // CUSTOM: To access the player preferences with the same pattern as all other paths in the engine
        public static string SharedPrefsPath => Path.Combine(DataPath, "shared_prefs");

        // CUSTOM: Sets root for all relative path properties
        public static void SetRoot(string root)
        {
            Root = root;

            EnsurePaths();
        }

        #endregion

        static Application()
        {
            EnsureVersions();
            EnsureIdentifiers();

            EnsurePaths();
        }

        #region App

        public static string Version
        {
            get => Versions[SystemLanguage];
            set => Versions[SystemLanguage] = value;
        }

        public static string Identifier => Identifiers[SystemLanguage];

        private static void EnsureVersions()
        {
            Versions[SystemLanguage.English] = "23.06.02";
        }

        private static void EnsureIdentifiers()
        {
            Identifiers[SystemLanguage.English] = "com.everywear.game5";
        }

        #endregion

        #region System

        public static SystemLanguage SystemLanguage => SystemLanguage.English;

        #endregion

        private static void EnsurePaths()
        {
            EnsureDirectory(DataPath);
            EnsureDirectory(PersistentDataPath);
            EnsureDirectory(ApkPath);

            EnsureDirectory(TemporaryCachePath);
            EnsureDirectory(SharedPrefsPath);
        }

        private static void EnsureDirectory(string dir)
        {
            Directory.CreateDirectory(dir);
        }
    }
}
