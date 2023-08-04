using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Web3
{
    [MetaSerializable]
    public struct NftOwnerAddress
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private NftOwnerAddress.AddressType _type;
        [MetaMember(2, (MetaMemberFlags)0)]
        private string _str;
        public static NftOwnerAddress None { get; }
        public NftOwnerAddress.AddressType Type { get; }
        public string AddressString { get; }

        [MetaSerializable]
        public enum AddressType
        {
            None = 0,
            Ethereum = 1
        }
    }
}