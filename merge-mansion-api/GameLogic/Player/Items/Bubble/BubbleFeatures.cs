using System;
using System.Runtime.Serialization;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializable]
    public class BubbleFeatures
    {
        private static MetaDuration defaultBubbleDuration = MetaDuration.FromMinutes(1);
        public static BubbleFeatures Placeholder = new(MetaDuration.FromMinutes(1), Currencies.Diamonds, 1000, null, 0);

        [MetaMember(1, 0)]
        public MetaDuration BubbleDuration { get; set; }

        [MetaMember(2, 0)]
        public Currencies OpenCurrency { get; set; }

        [MetaMember(3, 0)]
        public int OpenQuantity { get; set; }

        [MetaMember(4, 0)]
        private MetaRef<ItemDefinition> ReplacementItem { get; set; }

        [MetaMember(5, 0)]
        public int SpawnOdds { get; set; }

        [IgnoreDataMember] public ItemDefinition Replacement => ReplacementItem?.Deref();
        [IgnoreDataMember] public (Currencies, int) OpenCost => (OpenCurrency, OpenQuantity);

        private BubbleFeatures()
        {
        }

        public BubbleFeatures(MetaDuration bubbleDuration, Currencies openCurrency, int openQuantity, MetaRef<ItemDefinition> replacementItem, int spawnOdds)
        {
            BubbleDuration = bubbleDuration;
            OpenCurrency = openCurrency;
            OpenQuantity = openQuantity;
            ReplacementItem = replacementItem;
            SpawnOdds = spawnOdds;
        }
    }
}