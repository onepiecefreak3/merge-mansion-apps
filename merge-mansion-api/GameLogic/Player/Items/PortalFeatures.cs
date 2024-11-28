using GameLogic.Merge;
using Metaplay.Core.Model;
using Merge;
using System;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public class PortalFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsPortal { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeBoardId TargetBoardId { get; set; }

        public static PortalFeatures NoPortal;
        public PortalFeatures(MergeBoardId id)
        {
        }

        private PortalFeatures()
        {
        }
    }
}