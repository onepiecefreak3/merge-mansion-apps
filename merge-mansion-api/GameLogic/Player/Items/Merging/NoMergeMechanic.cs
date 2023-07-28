using System;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializableDerived(1)]
    public class NoMergeMechanic : IMergeMechanic
    {
        public bool CanMerge(MergeItem sourceItem, MergeItem targetItem)
        {
            throw new NotImplementedException();
        }

        public MergeItem Merge(IPlayer player, MergeItem sourceItem, MergeItem targetItem, MetaTime timestamp)
        {
            throw new InvalidOperationException("Attempt to merge item that has no merge mechanics.");
        }
    }
}
