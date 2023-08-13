using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(17)]
    [MetaFormHidden]
    public class ProgressionEventPremiumIAPReward : PlayerReward
    {
        [MetaMember(1, 0)]
        public ProgressionEventId EventId { get; set; }

        public ProgressionEventPremiumIAPReward()
        {
        }

        public ProgressionEventPremiumIAPReward(ProgressionEventId eventId)
        {
        }
    }
}