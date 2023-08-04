using Metaplay.Core;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player
{
    public class CurrencyAddedEvent : CopyableEvent<CurrencyAddedEvent, Currencies, long, long, CurrencySource, int, EventCurrencyId, AnalyticsContext>
    {
        public CurrencyAddedEvent()
        {
        }
    }
}