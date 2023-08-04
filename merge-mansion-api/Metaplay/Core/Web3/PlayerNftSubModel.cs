using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Web3
{
    [MetaSerializable]
    public class PlayerNftSubModel
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<NftKey, MetaNft> OwnedNfts { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerNftTransactionState TransactionState { get; set; }

        public PlayerNftSubModel()
        {
        }
    }
}