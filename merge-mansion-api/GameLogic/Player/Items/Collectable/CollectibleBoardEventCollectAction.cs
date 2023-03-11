using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core;
using Metaplay.Code.GameLogic.GameEvents;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(7)]
    public class CollectibleBoardEventCollectAction : IProgressCollectAction
    {
        [MetaMember(1, 0)]
        private MetaRef<CollectibleBoardEventInfo> CollectibleBoardEventRef { get; set; }
        [MetaMember(2, 0)]
        public int Progress { get; set; }
        [MetaMember(3, 0)]
        public bool LevelUpMergeChain { get; set; }
    }
}
