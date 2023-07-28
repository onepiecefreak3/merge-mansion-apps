using System.IO;
using System.Threading.Tasks;

namespace Metaplay.Core.Impl
{
    public class FileUtilImplFileSystem
    {
        public static async Task<bool> WriteAllBytesAtomicAsync(string filePath, byte[] bytes)
        {
            var tempPath = filePath + ".new";
            using var fsLock = await FileAccessLock.AcquireAsync(filePath);

            await WriteAllBytesAsync(tempPath, bytes);

            if (!File.Exists(filePath))
                File.Move(tempPath, filePath);
            else
                File.Replace(tempPath, filePath, null);

            return true;
        }

        public static async Task WriteAllBytesAsync(string filePath, byte[] bytes)
        {
            await File.WriteAllBytesAsync(filePath, bytes);
        }

        public static Task DeleteAsync(string filePath)
        {
            File.Delete(filePath);
            return Task.CompletedTask;
        }

        public static async Task<byte[]> ReadAllBytesAsync(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            return await File.ReadAllBytesAsync(filePath);
        }
    }
}
