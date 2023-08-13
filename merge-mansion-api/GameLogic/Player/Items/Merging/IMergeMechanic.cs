using Metaplay.Core;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;
using Metaplay.Core.Math;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializable]
    public interface IMergeMechanic
    {
        bool CanMerge(MergeItem sourceItem, MergeItem targetItem);
        MergeItem Merge(IPlayer player, MergeItem sourceItem, MergeItem targetItem, MetaTime timestamp);
        [IgnoreDataMember]
        IEnumerable<ValueTuple<ItemDefinition, F32>> PossibleMergeResults { get; }
    }
}