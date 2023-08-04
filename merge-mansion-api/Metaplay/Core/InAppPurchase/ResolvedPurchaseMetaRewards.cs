using Metaplay.Core.Model;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializableDerived(1000)]
    public class ResolvedPurchaseMetaRewards : ResolvedPurchaseContentBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<MetaPlayerRewardBase> Rewards { get; set; }

        public ResolvedPurchaseMetaRewards()
        {
        }

        public ResolvedPurchaseMetaRewards(IEnumerable<MetaPlayerRewardBase> rewards)
        {
        }
    }
}