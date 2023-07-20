using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core
{
    [MetaSerializable]
    public class MetaVersionRange
    {
        [MetaMember(1, 0)]
        public int MinVersion { get; set; } // 0x0
        [MetaMember(2, 0)]
        public int MaxVersion { get; set; } // 0x4

        public MetaVersionRange() { }

        public MetaVersionRange(int minVersion, int maxVersion)
        {
            MinVersion = minVersion;
            MaxVersion = maxVersion;
        }
    }
}
