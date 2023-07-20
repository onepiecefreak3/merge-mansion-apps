using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(14)]
    [MetaSerializable]
    public class RewardEventPoints : PlayerReward
    {
        [MetaMember(1, 0)]
        public EventId EventId { get; set; }
        [MetaMember(2, 0)]
        public int Amount { get; set; }
    }
}
