using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(3)]
    [MetaSerializable]
    public class RewardDiamonds : PlayerReward
    {
        [MetaMember(1, 0)]
        public int Amount { get; set; }
    }
}
