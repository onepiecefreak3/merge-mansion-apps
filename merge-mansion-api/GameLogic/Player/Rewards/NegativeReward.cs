using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Rewards
{
    [MetaSerializableDerived(8)]
    [MetaSerializable]
    public class NegativeReward : PlayerReward
    {
        [MetaMember(1, 0)]
        public Currencies Currency { get; set; }
        [MetaMember(2, 0)]
        public long RemoveAmount { get; set; }
        [MetaMember(3, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }
    }
}
