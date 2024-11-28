using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using GameLogic.Player.Items.Production;
using Metaplay.Core.Math;
using GameLogic.Merge;

namespace GameLogic.Player.Items.Merging
{
    [MetaReservedMembers(100, 199)]
    [MetaSerializableDerived(5)]
    public class MultipleItemsMergeMechanic : BaseMergeMechanic
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public List<int> AllowedItems { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public IItemProducer ResultProducer { get; set; }

        public override bool CanMerge(MergeItem sourceItem, MergeItem targetItem)
        {
            throw new NotImplementedException();
        }

        protected override ItemDefinition GetMergeProduct(IPlayer player, MergeItem sourceItem, MergeItem targetItem)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ValueTuple<ItemDefinition, F32>> PossibleMergeResults { get; }

        private MultipleItemsMergeMechanic()
        {
        }

        public MultipleItemsMergeMechanic(List<int> allowedItems, IItemProducer resultProducer, ItemVisibility resultVisibility)
        {
        }

        public MultipleItemsMergeMechanic(List<int> allowedItems, IItemProducer resultProducer, StorageActionType storageAction, bool resetTimers, ItemVisibility resultVisibility)
        {
        }
    }
}