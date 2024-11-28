using Metaplay.Core.Model;
using System.Collections.Generic;
using Merge;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(54)]
    public class MergeBoardIdRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<MergeBoardId> BoardIds { get; set; }

        public MergeBoardIdRequirement()
        {
        }

        public MergeBoardIdRequirement(List<MergeBoardId> boardIds)
        {
        }
    }
}