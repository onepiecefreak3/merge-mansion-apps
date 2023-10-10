using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaSerializable]
    public enum CompressionAlgorithm
    {
        None = 0,
        Deflate = 1,
        LZ4 = 2,
        Zstandard = 3
    }
}