using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using GameLogic.Config;

namespace Game.Logic
{
    [MetaActivableSet("OfferGroup", false)]
    [MetaSerializableDerived(1)]
    public class PlayerMergeMansionOffersGroupModel : PlayerMetaOfferGroupsModelBase<MergeMansionOfferGroupInfo>
    {
        public PlayerMergeMansionOffersGroupModel()
        {
        }
    }
}