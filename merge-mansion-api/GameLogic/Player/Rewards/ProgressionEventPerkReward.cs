using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(18)]
    [MetaSerializable]
    public class ProgressionEventPerkReward : PlayerReward
    {
        [MetaMember(1, 0)]
        public ProgressionEventPerkId PerkId { get; set; }
    }
}
