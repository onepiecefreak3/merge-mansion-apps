using GameLogic.Player.Items.Production;
using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using Metaplay.Core.Math;
using GameLogic.Merge;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializableDerived(2)]
    public class SameItemsMergeMechanic : BaseMergeMechanic
    {
        [MetaMember(4)]
        public IItemProducer ResultProducer { get; set; } // 0x18

        public override bool CanMerge(MergeItem sourceItem, MergeItem targetItem)
        {
            return sourceItem.Definition.ConfigKey == targetItem.Definition.ConfigKey;
        }

        protected override ItemDefinition GetMergeProduct(IPlayer player, MergeItem sourceItem, MergeItem targetItem)
        {
            return ResultProducer.Produce(player);
        }

        public override IEnumerable<ValueTuple<ItemDefinition, F32>> PossibleMergeResults { get; }

        private SameItemsMergeMechanic()
        {
        }

        public SameItemsMergeMechanic(IItemProducer resultProducer, ItemVisibility resultVisibility)
        {
        }

        public SameItemsMergeMechanic(IItemProducer resultProducer, StorageActionType storageAction, bool resetTimers, ItemVisibility resultVisibility)
        {
        }
    }
}