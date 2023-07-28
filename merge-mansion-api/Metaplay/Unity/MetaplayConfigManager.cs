using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Metaplay.Core;

namespace Metaplay.Unity
{
    public static class MetaplayConfigManager
    {
        public static void OnSessionStarted()
        {
            var versionSet = new HashSet<ContentHash>(MetaplaySDK.Connection.SessionStartResources.GameConfigBaselineVersions.Values);
            CleanConfigCacheDirectoryOnBackgroundAsync("SharedGameConfig", versionSet);

            versionSet = new HashSet<ContentHash>(MetaplaySDK.Connection.SessionStartResources.GameConfigPatchVersions.Values);
            CleanConfigCacheDirectoryOnBackgroundAsync("SharedGameConfigPatches", versionSet);
        }

        private static async void CleanConfigCacheDirectoryOnBackgroundAsync(string cacheDirName, HashSet<ContentHash> retainedVersions)
        {
            await DoCleanConfigCacheDirectoryOnBackgroundAsync(cacheDirName, retainedVersions);
        }
        
        private static async Task DoCleanConfigCacheDirectoryOnBackgroundAsync(string cacheDirName, HashSet<ContentHash> retainedVersions)
        {
            var cachePath = Path.Combine(MetaplaySDK.DownloadCachePath, cacheDirName);
            var files = await DirectoryUtil.GetDirectoryFilesAsync(cachePath);

            if (files.Length <= 9)
                return;

            foreach (var file in files)
            {
                if (!ContentHash.TryParseString(Path.GetFileName(file), out var hash))
                    continue;

                if(retainedVersions.Contains(hash))
                    continue;

                // Log info "Pruning cached {Name} version {Version}"
                File.Delete(file);
            }
        }
    }
}
