using Metaplay.Core.Model;
using Metaplay.Core.Rewards;
using Code.GameLogic.Config;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    public abstract class PlayerReward : MetaPlayerRewardBase, IValidatable
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public CurrencySource Source { get; set; }

        protected PlayerReward()
        {
        }
    }
}