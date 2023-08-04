using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(17)]
    public class ProgressionEventPremiumPurchasedRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private ProgressionEventId EventId { get; set; }

        private ProgressionEventPremiumPurchasedRequirement()
        {
        }

        public ProgressionEventPremiumPurchasedRequirement(ProgressionEventId id)
        {
        }
    }
}