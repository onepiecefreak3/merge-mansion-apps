using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(14, "Garage cleanup event leveled up", 1, null, true, false, false)]
    [AnalyticsEventKeywords(new string[] { "event" })]
    public class PlayerEventGarageCleanupLeveledUp : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupEventId EventId { get; set; }
        public override string EventDescription { get; }

        public PlayerEventGarageCleanupLeveledUp()
        {
        }

        public PlayerEventGarageCleanupLeveledUp(GarageCleanupEventId eventId)
        {
        }
    }
}