using GameLogic.Banks;
using Metaplay.Core.Model;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    public class RewardCurrencyBank : PlayerReward
    {
        [MetaMember(1, 0)]
        public CurrencyBankId CurrencyBankId { get; set; }
    }
}
