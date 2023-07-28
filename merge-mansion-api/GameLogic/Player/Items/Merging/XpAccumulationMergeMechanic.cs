using System;
using System.Collections.Generic;
using GameLogic.Merge;
using GameLogic.Player.Items.Production;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializableDerived(4)]
    [MetaSerializable]
    public class XpAccumulationMergeMechanic : IMergeMechanic
    {
        [MetaMember(1, 0)]
        public ItemVisibility ResultVisibility { get; set; }
        [MetaMember(2, 0)]
        public bool FlushStorage { get; set; }
        [MetaMember(3, 0)]
        public bool ResetTimers { get; set; }
        [MetaMember(4, 0)]
        public IItemProducer ResultProducer { get; set; }
        [MetaMember(5, 0)]
        public int ExperienceRequired { get; set; }
        [MetaMember(6, 0)]
        private List<MetaRef<MergeReward>> MergeRewardsRefs { get; set; }

        public bool CanMerge(MergeItem sourceItem, MergeItem targetItem)
        {
            throw new NotImplementedException();
        }

        public MergeItem Merge(IPlayer player, MergeItem sourceItem, MergeItem targetItem, MetaTime timestamp)
        {
            throw new NotImplementedException();
        }
    }
}
