using Code.GameLogic.GameEvents;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(7)]
    [MetaSerializable]
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
