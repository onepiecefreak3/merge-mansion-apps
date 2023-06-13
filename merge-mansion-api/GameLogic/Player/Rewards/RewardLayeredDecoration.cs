using Metaplay.GameLogic.Decorations;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace merge_mansion_api.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(21)]
    public class RewardLayeredDecoration : PlayerReward
    {
        [MetaMember(1, 0)]
        private MetaRef<DecorationInfo> DecorationRef { get; set; }
        [MetaMember(2, 0)]
        public int Progress { get; set; }
    }
}
