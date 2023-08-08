using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(20, "Garage cleanup event started", 1, null, true, false, false)]
    public class PlayerEventGarageCleanupStartedLevel : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupEventId EventId { get; set; }
        public override string EventDescription { get; }

        public PlayerEventGarageCleanupStartedLevel()
        {
        }

        public PlayerEventGarageCleanupStartedLevel(GarageCleanupEventId eventId)
        {
        }
    }
}