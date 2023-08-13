using GameLogic.Merge;
using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializableDerived(3)]
    public class MergeCollectionMergeMechanics : BaseMergeMechanic
    {
        [MetaMember(4)]
        public MergeCollection MergeCollection { get; set; } // 0x18

        public override bool CanMerge(MergeItem sourceItem, MergeItem targetItem)
        {
            return MergeCollection.ContainsPair((sourceItem.Definition.ConfigKey, targetItem.Definition.ConfigKey));
        }

        protected override ItemDefinition GetMergeProduct(IPlayer player, MergeItem sourceItem, MergeItem targetItem)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<ValueTuple<ItemDefinition, F32>> PossibleMergeResults { get; }

        private MergeCollectionMergeMechanics()
        {
        }

        public MergeCollectionMergeMechanics(MergeCollection mergeCollection, ItemVisibility resultVisibility)
        {
        }

        public MergeCollectionMergeMechanics(MergeCollection mergeCollection, StorageActionType storageAction, bool resetTimers, ItemVisibility resultVisibility)
        {
        }
    }
}