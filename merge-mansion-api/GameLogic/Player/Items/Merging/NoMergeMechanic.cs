using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Merging
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
