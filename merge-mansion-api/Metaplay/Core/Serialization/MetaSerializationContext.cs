using System.Text;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Serialization
{
    public struct MetaSerializationContext
    {
        public readonly MetaMemberFlags ExcludeFlags; // 0x0
        public readonly IGameConfigDataResolver Resolver; // 0x8
        public readonly int? LogicVersion; // 0x10
        public readonly StringBuilder DebugStream; // 0x18

        public int MaxStringSize => 0x4000000;
        public int MaxByteArraySize => 0x4000000;
        public int MaxCollectionSize => 0x4000;

        public MetaSerializationContext(MetaSerializationFlags flags, IGameConfigDataResolver resolver, int? logicVersion, StringBuilder debugStream)
        {
            ExcludeFlags = (MetaMemberFlags) flags;
            Resolver = resolver;
            LogicVersion = logicVersion;
            DebugStream = debugStream;
        }
    }
}
