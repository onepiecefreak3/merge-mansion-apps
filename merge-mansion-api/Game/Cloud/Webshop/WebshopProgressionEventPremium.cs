using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using Metaplay.Core.InAppPurchase;
using System;

namespace Game.Cloud.Webshop
{
    [MetaBlockedMembers(new int[] { 2 })]
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

        public WebshopProgressionEventPremium(ProgressionEventId id, ProgressionEventTrack track)
        {
        }

        private static string PrefixMysteryPass;
        private static string PrefixMysteryPassV2;
        [MetaMember(3, (MetaMemberFlags)0)]
        public PurchasedProgressionEventTrackOption PurchasedTrackOption { get; set; }

        public WebshopProgressionEventPremium(ProgressionEventId id, PurchasedProgressionEventTrackOption track)
        {
        }
    }
}