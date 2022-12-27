using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core
{
    public class DiskBlobStorage : IBlobStorage
    {
        // Fields
        private readonly string _dirName; // 0x10

        public DiskBlobStorage(string dirName)
        {
            _dirName = dirName ?? throw new ArgumentNullException(nameof(dirName));

            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);
        }

        public void Dispose() { }

        public string[] GetFilesSync(string directory)
        {
            var path = Path.Combine(_dirName, directory);
            var files = Directory.GetFiles(path);

            return files.Select(Path.GetFileName).ToArray();
        }

        public async Task<byte[]> GetAsync(string fileName)
        {
            var path = Path.Combine(_dirName, fileName);
            return await FileUtil.ReadAllBytesAsync(path);
        }

        public async Task<bool> PutAsync(string fileName, byte[] bytes, BlobStoragePutHints hintsMaybe)
        {
            var dir = Path.GetDirectoryName(fileName);
            if (!string.IsNullOrEmpty(dir))
            {
                var path = Path.Combine(_dirName, dir);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }

            var fullDestinationPath = Path.Combine(_dirName, fileName);
            var filePath = string.Concat(fullDestinationPath, ".new");
            await FileUtil.WriteAllBytesAsync(filePath, bytes);

            File.Delete(fullDestinationPath);
            File.Move(filePath, fullDestinationPath);

            return true;
        }

        public async Task DeleteAsync(string fileName)
        {
            var path = Path.Combine(_dirName, fileName);
            await FileUtil.DeleteAsync(path);
        }
    }
}
