using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(9)]
    public class CollectEventCurrencyAction : ICollectAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventCurrencyId EventCurrencyId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        private CollectEventCurrencyAction()
        {
        }

        public CollectEventCurrencyAction(EventCurrencyId eventCurrencyId, int amount)
        {
        }
    }
}