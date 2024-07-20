using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using GameLogic.Config;

namespace Game.Logic
{
    [MetaSerializableDerived(1)]
    [MetaActivableSet("OfferGroup", false)]
    public class PlayerMergeMansionOffersGroupModel : PlayerMetaOfferGroupsModelBase<MergeMansionOfferGroupInfo>
    {
        public PlayerMergeMansionOffersGroupModel()
        {
        }
    }
}