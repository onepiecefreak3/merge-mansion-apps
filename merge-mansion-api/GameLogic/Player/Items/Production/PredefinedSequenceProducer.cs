using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using Metaplay.Core;
using System.Runtime.Serialization;
using GameLogic.Random;
using Metaplay.Core.Math;
using System.Linq;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(13)]
    public class PredefinedSequenceProducer : IItemSpawner, IItemProducer
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<ItemOdds> OddsList { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private ulong TotalCount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private HashSet<MetaRef<ItemDefinition>> UniqueItems { get; set; }

        [IgnoreDataMember]
        public IEnumerable<ValueTuple<ItemDefinition, int>> Odds => OddsList.Select(x => (x.Type.Deref(), x.Weight));

        public int SpawnQuantity => 1;

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            /*	private int <>1__state; // 0x10
	            private ItemDefinition <>2__current; // 0x18
	            private int <>l__initialThreadId; // 0x20
	            private int quantity; // 0x24
	            public int <>3__quantity; // 0x28
	            public PredefinedSequenceProducer <>4__this; // 0x30
	            private ProducerContext producerContext; // 0x38
	            public ProducerContext <>3__producerContext; // 0x40
	            private ulong <itemIndex>5__2; // 0x48
	            private ulong <accumulatedIndex>5__3; // 0x50
	            private int <accumulatedQuantity>5__4; // 0x58
	            private List.Enumerator<ItemOdds> <>7__wrap4; // 0x60
	            private ItemOdds <odds>5__6; // 0x78
	            private int <weight>5__7; // 0x80
	            private int <i>5__8; // 0x84 */
            throw new NotImplementedException();
        }

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return OddsList.Average(x => x.Type.Ref.TimeSkipPriceGems);
        }

        private PredefinedSequenceProducer()
        {
        }

        public PredefinedSequenceProducer(IEnumerable<ValueTuple<int, int>> oddsList)
        {
        }
    }
}