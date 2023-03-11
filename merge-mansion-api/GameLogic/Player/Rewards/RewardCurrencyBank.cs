using Metaplay.GameLogic.Player.Rewards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Banks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    public class RewardCurrencyBank : PlayerReward
    {
        [MetaMember(1, 0)]
        public CurrencyBankId CurrencyBankId { get; set; }
    }
}
