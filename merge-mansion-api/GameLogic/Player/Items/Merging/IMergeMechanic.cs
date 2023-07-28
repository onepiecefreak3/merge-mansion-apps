using Metaplay.Core;

namespace GameLogic.Player.Items.Merging
{
    public interface IMergeMechanic
    {
        //IEnumerable<ValueTuple<ItemDefinition, F32>> PossibleMergeResults { get; }

        bool CanMerge(MergeItem sourceItem, MergeItem targetItem);
        MergeItem Merge(IPlayer player, MergeItem sourceItem, MergeItem targetItem, MetaTime timestamp);
        //IEnumerable<ValueTuple<ItemDefinition, F32>> get_PossibleMergeResults();
    }
}
