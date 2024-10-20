using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using Metaplay.Core.InAppPurchase;
using System;

namespace Game.Cloud.Webshop
{
    [MetaSerializableDerived(3)]
    public class WebshopProgressionEventPremium : WebshopItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventId Id { get; set; }
        public override InAppProductId ProductId { get; }
        public override bool ShouldEarlyConsume { get; }

        private WebshopProgressionEventPremium()
        {
        }

        public WebshopProgressionEventPremium(ProgressionEventId id)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ProgressionEventTrack Track { get; set; }

        public WebshopProgressionEventPremium(ProgressionEventId id, ProgressionEventTrack track)
        {
        }
    }
}