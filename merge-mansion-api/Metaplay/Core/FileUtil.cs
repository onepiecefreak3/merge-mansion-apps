using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core
{
    public static class FileUtil
    {
        public static async Task<byte[]> ReadAllBytesAsync(string filePath)
        {
            if (IsRemotePath(filePath))
                return await ReadRemoteFileBytesAsync(filePath);

            if (!File.Exists(filePath))
                return null;

            return await File.ReadAllBytesAsync(filePath);
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

        public static byte[] ReadAllBytes(string filePath)
        {
            if (IsRemotePath(filePath))
                return ReadRemoteFileBytesSync(filePath);

            if (!File.Exists(filePath))
                return null;

            return File.ReadAllBytes(filePath);
        }

        public static string ReadAllText(string filePath)
        {
            if (IsRemotePath(filePath))
                return ReadRemoteFileTextSync(filePath);

            if (!File.Exists(filePath))
                return null;

            return File.ReadAllText(filePath);
        }

        public static string[] ReadAllLines(string filePath)
        {
            var res = new List<string>();

            var text = ReadAllText(filePath);
            if (text == null)
                return null;

            using var reader = new StringReader(text);

            var line = reader.ReadLine();
            while (line != null)
            {
                res.Add(line);
                line = reader.ReadLine();
            }

            return res.ToArray();
        }

        public static byte[] ReadRemoteFileBytesSync(string filePath)
        {
            var req = WebRequest.CreateHttp(filePath);
            using var response = req.GetResponse();
            using var dataStream = response.GetResponseStream();

            var dest = new MemoryStream();
            dataStream?.CopyTo(dest);

            return dest.ToArray();
        }

        public static string ReadRemoteFileTextSync(string filePath)
        {
            var req = WebRequest.CreateHttp(filePath);
            using var response = req.GetResponse();
            using var dataStream = response.GetResponseStream();

            using var reader = new StreamReader(dataStream);

            return reader.ReadToEnd();
        }

        public static async Task<byte[]> ReadRemoteFileBytesAsync(string filePath)
        {
            var req = WebRequest.CreateHttp(filePath);
            using var response = await req.GetResponseAsync();
            await using var dataStream = response.GetResponseStream();

            var dest = new MemoryStream();
            await dataStream.CopyToAsync(dest);

            return dest.ToArray();
        }

        public static bool IsRemotePath(string filePath)
        {
            return filePath.Contains("jar:file:/");
        }
    }
}
