using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(4)]
    public class PlayerEventOfferModel : MetaActivableSet<EventOfferId, EventOfferInfo, EventOfferModel>
    {
        public PlayerEventOfferModel()
        {
        }
    }
}