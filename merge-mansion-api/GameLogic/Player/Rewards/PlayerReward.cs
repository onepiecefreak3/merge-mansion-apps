using Metaplay.Core.Model;
using Metaplay.Core.Rewards;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    public abstract class PlayerReward:MetaPlayerRewardBase
    {
        [MetaMember(100)]
        public CurrencySource Source { get; set; }
    }
}
