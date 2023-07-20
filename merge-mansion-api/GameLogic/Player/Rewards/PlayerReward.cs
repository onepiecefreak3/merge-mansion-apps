using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Rewards;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializable]
    public abstract class PlayerReward:MetaPlayerRewardBase
    {
        [MetaMember(100)]
        public CurrencySource Source { get; set; }
    }
}
