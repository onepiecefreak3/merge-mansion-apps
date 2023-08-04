using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Web3
{
    [MetaSerializable]
    public struct NftId
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ulong Value;
        public static NftId Zero { get; }
    }
}