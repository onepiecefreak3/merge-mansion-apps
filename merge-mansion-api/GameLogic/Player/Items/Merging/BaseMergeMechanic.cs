using GameLogic.Merge;
using GameLogic.Random;
using Metaplay.Core;
using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializable]
    public abstract class BaseMergeMechanic : IMergeMechanic
    {
        [MetaMember(1)]
        public ItemVisibility ResultVisibility { get; set; } // 0x10

        [MetaMember(3)]
        public bool ResetTimers { get; set; } // 0x15

        /// <summary>
        /// Checks if two items can be merged under given rules.
        /// </summary>
        /// <param name = "sourceItem">Item 1</param>
        /// <param name = "targetItem">Item 2</param>
        /// <returns>If items can be merged.</returns>
        public abstract bool CanMerge(MergeItem sourceItem, MergeItem targetItem);
        /// <summary>
        /// Gets the item definition to be produced from the merge action.
        /// </summary>
        /// <param name = "player">The player, who executes the merge action.</param>
        /// <param name = "sourceItem">Item 1</param>
        /// <param name = "targetItem">Item 2</param>
        /// <returns>The item definition to produce.</returns>
        protected abstract ItemDefinition GetMergeProduct(IPlayer player, MergeItem sourceItem, MergeItem targetItem);
        /// <summary>
        /// Merge two items together.
        /// </summary>
        /// <param name = "player">The player, who executes the merge action.</param>
        /// <param name = "sourceItem">Item 1</param>
        /// <param name = "targetItem">Item 2</param>
        /// <param name = "timestamp">Moment of merge for time based producers.</param>
        /// <returns>The final merged item.</returns>
        public MergeItem Merge(IPlayer player, MergeItem sourceItem, MergeItem targetItem, MetaTime timestamp)
        {
            var itemDefinition = GetMergeProduct(player, sourceItem, targetItem);
            var generationContext = new GenerationContext(player, null);
            var combinedItem = itemDefinition.Combine(sourceItem, targetItem, timestamp, generationContext, ResultVisibility);
            if (ResetTimers)
                combinedItem.ResetStates(timestamp);
            if (StorageAction == StorageActionType.Reset)
                combinedItem.FlushStorages();
            return combinedItem;
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public StorageActionType StorageAction { get; set; }
        public abstract IEnumerable<ValueTuple<ItemDefinition, F32>> PossibleMergeResults { get; }

        protected BaseMergeMechanic()
        {
        }

        protected BaseMergeMechanic(ItemVisibility resultVisibility, StorageActionType storageAction, bool resetTimers)
        {
        }
    }
}