using Metaplay.Core.Model;
using Metaplay.Core.Math;
using GameLogic.Player.Rewards;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class WeightStarRewardData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F32 Weight { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerReward Reward { get; set; }

        private WeightStarRewardData()
        {
        }

        public WeightStarRewardData(F32 weight, PlayerReward reward)
        {
        }
    }
}