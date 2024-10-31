using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializableDerived(15)]
    [MetaFormHidden]
    public class RewardExtendGameEvents : PlayerReward
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public EventId EventId { get; set; }

        public RewardExtendGameEvents()
        {
        }

        public RewardExtendGameEvents(string eventId)
        {
        }
    }
}