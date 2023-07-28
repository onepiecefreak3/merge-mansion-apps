using GameLogic.Merge;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public class PortalFeatures
    {
        [MetaMember(1, 0)]
        public bool IsPortal { get; set; }
        [MetaMember(2, 0)]
        public MergeBoardId TargetBoardId { get; set; }
    }
}
