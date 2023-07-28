using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Metaplay.Core.Impl;

namespace Metaplay.Core
{
    public static class FileUtil
    {
        public static async Task<byte[]> ReadAllBytesAsync(string filePath)
        {
            if (IsRemotePath(filePath))
                return await ReadRemoteFileBytesAsync(filePath);

            return await FileUtilImplFileSystem.ReadAllBytesAsync(filePath);
        }

        public static Task<bool> WriteAllBytesAtomicAsync(string filePath, byte[] bytes)
        {
            return FileUtilImplFileSystem.WriteAllBytesAtomicAsync(filePath, bytes);
        }

        public static async Task WriteAllBytesAsync(string filePath, byte[] bytes)
        {
            await File.WriteAllBytesAsync(filePath, bytes);
        }

        public static Task DeleteAsync(string filePath)
        {
            return FileUtilImplFileSystem.DeleteAsync(filePath);
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

        public static string NormalizePath(string path)
        {
            if (path == string.Empty)
                return string.Empty;

            var split = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            var i = 1;
            if (split[0] != string.Empty)
                i = split[0].Contains(':') ? 1 : 0;

            var stack = new Stack<string>();

            var j = 0;
            if (i < split.Length)
            {
                for (var s = i; s < split.Length; s++)
                {
                    if (split[s] != string.Empty)
                    {
                        if (split[s] != "..")
                        {
                            if (split[s] != ".")
                                stack.Push(split[s]);
                        }
                        else
                        {
                            if (stack.Count < 1)
                            {
                                if (i != 0)
                                    throw new ArgumentException($"Absolute path '{path}' references the parent of the root directory");

                                j++;
                            }
                            else
                                stack.Pop();
                        }
                    }
                    else if (split.Length - 1 != i)
                        throw new ArgumentException($"Path '{path}' is invalid: contains two subsequent directory separators");
                }
            }

            if (i == 0)
                return string.Join('/', Enumerable.Repeat("..", j).Concat(stack.Reverse()));
            
            return split[0] + '/' + string.Join('/', stack.Reverse());
        }
    }
}
