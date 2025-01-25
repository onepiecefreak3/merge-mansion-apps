using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using GameLogic.ProgressivePacks;
using Code.GameLogic.GameEvents;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Game.Logic
{
    [MetaSerializableDerived(6)]
    public class ProgressionPackEventDynamicPurchaseContent : DynamicPurchaseContent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionPackEventId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ProgressionEventTrack Track { get; set; }
        public override List<MetaPlayerRewardBase> PurchaseRewards { get; }

        private ProgressionPackEventDynamicPurchaseContent()
        {
        }

        public ProgressionPackEventDynamicPurchaseContent(ProgressionPackEventId eventId, ProgressionEventTrack track)
        {
        }
    }
}