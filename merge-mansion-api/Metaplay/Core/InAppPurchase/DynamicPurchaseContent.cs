using Metaplay.Core.Model;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    public abstract class DynamicPurchaseContent
    {
        public abstract List<MetaPlayerRewardBase> PurchaseRewards { get; }

        protected DynamicPurchaseContent()
        {
        }
    }
}