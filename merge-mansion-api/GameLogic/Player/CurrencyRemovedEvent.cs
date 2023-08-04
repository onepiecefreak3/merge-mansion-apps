using Metaplay.Core;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player
{
    public class CurrencyRemovedEvent : CopyableEvent<CurrencyRemovedEvent, Currencies, long, long, CurrencySink, int, EventCurrencyId, AnalyticsContext>
    {
        public CurrencyRemovedEvent()
        {
        }
    }
}