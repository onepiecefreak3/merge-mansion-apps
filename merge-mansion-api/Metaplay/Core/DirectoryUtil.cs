using System;
using System.IO;
using System.Threading.Tasks;

namespace Metaplay.Core
{
    public static class DirectoryUtil
    {
        public static Task<string[]> GetDirectoryFilesAsync(string directory)
        {
            var files = Directory.GetFiles(directory);
            CanonizeFolderSeparatorsInPlace(files);

            return Task.FromResult(files);
        }

        public static Task<string[]> GetDirectoryAndSubdirectoryFilesAsync(string directory)
        {
            if (!Directory.Exists(directory))
                return Task.FromResult(Array.Empty<string>());

            var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            CanonizeFolderSeparatorsInPlace(files);

            return Task.FromResult(files);
        }

        public static Task EnsureDirectoryExistsAsync(string directory)
        {
            Directory.CreateDirectory(directory);
            return Task.CompletedTask;
        }

        private static void CanonizeFolderSeparatorsInPlace(string[] paths)
        {
            if (paths.Length <= 0)
                return;

            for (var i = 0; i < paths.Length; i++)
                paths[i] = paths[i].Replace("\\", "/");
        }
    }
}
