using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormHidden]
    [MetaSerializableDerived(18)]
    public class ProgressionEventPerkReward : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventPerkId PerkId { get; set; }

        public ProgressionEventPerkReward()
        {
        }

        public ProgressionEventPerkReward(ProgressionEventPerkId perkId)
        {
        }
    }
}