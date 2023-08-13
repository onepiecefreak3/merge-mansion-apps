using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(8)]
    [MetaFormHidden]
    public class NegativeReward : PlayerReward
    {
        [MetaMember(1, 0)]
        public Currencies Currency { get; set; }

        [MetaMember(2, 0)]
        public long RemoveAmount { get; set; }

        [MetaMember(3, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }

        public NegativeReward()
        {
        }

        public NegativeReward(Currencies currency, long maxRemoveAmount)
        {
        }

        public NegativeReward(EventCurrencyId eventCurrencyId, long maxRemoveAmount)
        {
        }
    }
}