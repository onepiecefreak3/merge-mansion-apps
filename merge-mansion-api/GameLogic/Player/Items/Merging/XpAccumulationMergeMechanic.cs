using System;
using System.Collections.Generic;
using GameLogic.Merge;
using GameLogic.Player.Items.Production;
using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializableDerived(4)]
    [MetaBlockedMembers(new int[] { 2 })]
    public class XpAccumulationMergeMechanic : IMergeMechanic
    {
        [MetaMember(1, 0)]
        public ItemVisibility ResultVisibility { get; set; }

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

        [MetaMember(7, (MetaMemberFlags)0)]
        public StorageActionType StorageAction { get; set; }
        public IEnumerable<MergeReward> MergeRewards { get; }
        public IEnumerable<ValueTuple<ItemDefinition, F32>> PossibleMergeResults { get; }

        private XpAccumulationMergeMechanic()
        {
        }

        public XpAccumulationMergeMechanic(IItemProducer resultProducer, StorageActionType storageAction, bool resetTimers, ItemVisibility resultVisibility, int experienceRequired, IEnumerable<MetaRef<MergeReward>> mergeRewards)
        {
        }
    }
}