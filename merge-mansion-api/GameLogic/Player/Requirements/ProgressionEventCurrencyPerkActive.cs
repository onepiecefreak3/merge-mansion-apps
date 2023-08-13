using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(20)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class ProgressionEventCurrencyPerkActive : PlayerRequirement
    {
        private ProgressionEventCurrencyPerkActive()
        {
        }

        public ProgressionEventCurrencyPerkActive(ProgressionEventId eventId)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        private ProgressionEventPerkId ProgressionEventPerkId { get; set; }

        public ProgressionEventCurrencyPerkActive(ProgressionEventPerkId progressionEventPerkId)
        {
        }
    }
}