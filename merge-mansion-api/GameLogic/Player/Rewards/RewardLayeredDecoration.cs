using GameLogic.Decorations;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(21)]
    [MetaSerializable]
    public class RewardLayeredDecoration : PlayerReward
    {
        [MetaMember(1, 0)]
        private MetaRef<DecorationInfo> DecorationRef { get; set; }
        [MetaMember(2, 0)]
        public int Progress { get; set; }
    }
}
