using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(20)]
    public class ProgressionEventCurrencyPerkActive : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private ProgressionEventId EventId { get; set; }

        private ProgressionEventCurrencyPerkActive()
        {
        }

        public ProgressionEventCurrencyPerkActive(ProgressionEventId eventId)
        {
        }
    }
}