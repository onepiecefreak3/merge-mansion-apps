using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;
using Code.GameLogic.GameEvents;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Game.Logic
{
    [MetaSerializableDerived(2)]
    public class GameEventExtensionDynamicPurchaseContent : DynamicPurchaseContent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [Obsolete]
        public EventId EventId_DEPRECATED { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string EventId { get; set; }
        public override List<MetaPlayerRewardBase> PurchaseRewards { get; }

        private GameEventExtensionDynamicPurchaseContent()
        {
        }

        public GameEventExtensionDynamicPurchaseContent(string eventId)
        {
        }
    }
}