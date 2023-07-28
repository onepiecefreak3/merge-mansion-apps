using Code.GameLogic.GameEvents;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(22)]
    [MetaSerializable]
    public class RewardCollectibleBoardEventProgress : PlayerReward
    {
        [MetaMember(1, 0)]
        private MetaRef<CollectibleBoardEventInfo> EventInfoRef { get; set; }
        [MetaMember(2, 0)]
        public int Amount { get; set; }
    }
}
