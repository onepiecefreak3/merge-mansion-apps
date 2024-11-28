using GameLogic.Player.Items.Production;
using Metaplay.Core.Model;
using System;
using GameLogic.Merge;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializable]
    public class MergeFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public IMergeMechanic Mechanic { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public IItemProducer AdditionalSpawnProducer { get; set; }

        public static MergeFeatures NoMerge;
        public bool Mergeable { get; }
        public bool RequiresXpState { get; }

        public MergeFeatures()
        {
        }

        public MergeFeatures(IItemProducer producer)
        {
        }

        public MergeFeatures(MergeCollection collection)
        {
        }

        public MergeFeatures(IMergeMechanic mergeMechanic)
        {
        }

        public MergeFeatures(IMergeMechanic mergeMechanic, IItemProducer additionalSpawnProducer)
        {
        }
    }
}