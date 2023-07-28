using System;
using System.IO;
using System.IO.Compression;

namespace Metaplay.Core
{
    public static class CompressUtil
    {
        public static byte[] DeflateCompress(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            using var ms = new MemoryStream();
            using var ds = new DeflateStream(ms, CompressionLevel.Fastest);

            ds.Write(input, 0, input.Length);

            return ms.ToArray();
        }

        public static byte[] DeflateDecompress(byte[] compressed, int offset = 0, int length = -1, int maxDecompressedSize = -1)
        {
            if (compressed == null)
                throw new ArgumentNullException(nameof(compressed));

            if (length < 0)
                length = compressed.Length - offset;

            using var decompressedStream = new MemoryStream();
            using var compressedStream = new MemoryStream(compressed, offset, length);
            using var deflateStream = new DeflateStream(compressedStream, CompressionMode.Decompress, false);
            if (maxDecompressedSize < 0)
                deflateStream.CopyTo(decompressedStream);
            else
            {
                using var limitedReadStream = new LimitedReadStream(deflateStream, maxDecompressedSize);
                limitedReadStream.CopyTo(decompressedStream);
            }

            return decompressedStream.ToArray();
        }

        public static bool IsSupportedForDecompression(CompressionAlgorithm compression)
        {
            return (int)compression < 2;
        }

        public static CompressionAlgorithmSet GetSupportedDecompressionAlgorithms()
        {
            var set = new CompressionAlgorithmSet();
            set.Add(CompressionAlgorithm.Deflate);

            return set;
        }
    }
}
