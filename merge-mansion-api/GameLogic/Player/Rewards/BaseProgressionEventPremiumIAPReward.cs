using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(44)]
    [MetaFormHidden]
    public class BaseProgressionEventPremiumIAPReward : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ProgressionEventTrack Track { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public EventType EventType { get; set; }

        public BaseProgressionEventPremiumIAPReward()
        {
        }

        public BaseProgressionEventPremiumIAPReward(string eventId, EventType eventType, ProgressionEventTrack track)
        {
        }
    }
}