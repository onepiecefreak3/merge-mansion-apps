using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;
using GameLogic.Fallbacks;

namespace GameLogic.Player.Items
{
    [MetaSerializableDerived(3)]
    public class TemporaryCardCollectionPocketOnlyItem : IBoardItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public CurrencySource Source { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public TemporaryCardCollectionEventId EventId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public FallbackPlayerRewardId FallbackReward { get; set; }

        public TemporaryCardCollectionPocketOnlyItem()
        {
        }

        public TemporaryCardCollectionPocketOnlyItem(int itemId, string itemType, CurrencySource source, FallbackPlayerRewardId fallbackReward, TemporaryCardCollectionEventId eventId)
        {
        }
    }
}