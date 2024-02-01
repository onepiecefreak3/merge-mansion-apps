using Metaplay.Core.Model;
using Merge;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(25)]
    public class BoardMergeCountRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MergeBoardId BoardId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int MergeCount;
        public BoardMergeCountRequirement()
        {
        }

        public BoardMergeCountRequirement(MergeBoardId boardId, int mergeCount)
        {
        }
    }
}