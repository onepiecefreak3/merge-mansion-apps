using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(15)]
    [MetaSerializable]
    public class RewardExtendGameEvents : PlayerReward
    {
        [MetaMember(1, 0)]
        public EventId EventId { get; set; }
    }
}
