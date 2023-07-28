using System;
using System.Runtime.Serialization;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializable]
    public class BubbleFeatures
    {
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

        [IgnoreDataMember]
        public ItemDefinition Replacement { get; }
        [IgnoreDataMember]
        public ValueTuple<Currencies, int> OpenCost { get; }
	}
}
