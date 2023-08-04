using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using Code.GameLogic.GameEvents;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Game.Logic
{
    [MetaSerializableDerived(3)]
    public class ProgressionEventDynamicPurchaseContent : DynamicPurchaseContent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventId EventId { get; set; }
        public override List<MetaPlayerRewardBase> PurchaseRewards { get; }

        private ProgressionEventDynamicPurchaseContent()
        {
        }

        public ProgressionEventDynamicPurchaseContent(ProgressionEventId eventId)
        {
        }
    }
}