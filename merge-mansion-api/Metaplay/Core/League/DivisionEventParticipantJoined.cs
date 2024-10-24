using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    [AnalyticsEvent(1301, null, 1, "A participant joined the division. Either assigned by the league manager, or by the participant themselves.", true, true, false)]
    public class DivisionEventParticipantJoined : DivisionEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [FirebaseAnalyticsIgnore]
        public DivisionEventParticipantInfo ParticipantInfo { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool SentByLeagueManager { get; set; }
        public override string EventDescription { get; }

        private DivisionEventParticipantJoined()
        {
        }

        public DivisionEventParticipantJoined(DivisionEventParticipantInfo participant, bool sentByLeagueManager)
        {
        }
    }
}