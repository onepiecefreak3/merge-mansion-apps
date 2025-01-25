using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using GameLogic.ProgressivePacks;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(45)]
    [MetaFormHidden]
    public class ProgressionPackEventPremiumIAPReward : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionPackEventId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ProgressionEventTrack Track { get; set; }

        public ProgressionPackEventPremiumIAPReward()
        {
        }

        public ProgressionPackEventPremiumIAPReward(ProgressionPackEventId eventId, ProgressionEventTrack track)
        {
        }
    }
}