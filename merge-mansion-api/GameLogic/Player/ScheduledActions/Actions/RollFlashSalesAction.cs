using Metaplay.Core.Model;
using Metaplay.Core.Offers;

namespace GameLogic.Player.ScheduledActions.Actions
{
    [MetaSerializableDerived(2)]
    public class RollFlashSalesAction : IScheduledAction
    {
        public RollFlashSalesAction()
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        public OfferPlacementId PlacementId { get; set; }

        public RollFlashSalesAction(OfferPlacementId placementId)
        {
        }
    }
}