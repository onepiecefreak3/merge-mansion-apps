using Metaplay.Core.Model;
using Merge;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(26)]
    public class BoardItemDiscoveredRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MergeBoardId BoardId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Item;
        public BoardItemDiscoveredRequirement()
        {
        }

        public BoardItemDiscoveredRequirement(MergeBoardId boardId, int item)
        {
        }
    }
}