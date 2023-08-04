using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Web3
{
    [MetaSerializable]
    public class PlayerNftTransactionState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<NftKey, MetaNft> Nfts { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerNftTransaction.ContextBase UserContext { get; set; }

        public PlayerNftTransactionState()
        {
        }
    }
}