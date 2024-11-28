using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormHidden]
    [MetaSerializableDerived(17)]
    public class ProgressionEventPremiumIAPReward : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventId EventId { get; set; }

        public ProgressionEventPremiumIAPReward()
        {
        }

        public ProgressionEventPremiumIAPReward(ProgressionEventId eventId)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ProgressionEventTrack Track { get; set; }

        public ProgressionEventPremiumIAPReward(ProgressionEventId eventId, ProgressionEventTrack track)
        {
        }
    }
}