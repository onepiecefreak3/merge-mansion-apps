using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(2)]
    public class RewardExperience : PlayerReward
    {
        [MetaMember(1, 0)]
        public int Amount { get; set; }
    }
}
