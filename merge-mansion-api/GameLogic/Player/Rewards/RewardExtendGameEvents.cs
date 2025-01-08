using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormHidden]
    [MetaSerializableDerived(15)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class RewardExtendGameEvents : PlayerReward
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        public RewardExtendGameEvents()
        {
        }

        public RewardExtendGameEvents(string eventId)
        {
        }
    }
}