using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Bubble
{
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
