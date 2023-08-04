using Metaplay.Core.Model;

namespace Metaplay.Core.Web3
{
    [MetaSerializable]
    public struct NftKey
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public NftCollectionId CollectionId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public NftId TokenId;
    }
}