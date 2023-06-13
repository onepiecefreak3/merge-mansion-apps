using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace merge_mansion_api.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(22)]
    public class RewardCollectibleBoardEventProgress : PlayerReward
    {
        [MetaMember(1, 0)]
        private MetaRef<CollectibleBoardEventInfo> EventInfoRef { get; set; }
        [MetaMember(2, 0)]
        public int Amount { get; set; }
    }
}
