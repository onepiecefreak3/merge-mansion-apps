using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Config
{
    [MetaSerializableDerived(14)]
    public class MergeMansionOfferGroupModel : MetaOfferGroupModelBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool PendingManualActivation { get; set; }

        [IgnoreDataMember]
        public int ManuallyTriggeredThisSession { get; set; }

        public MergeMansionOfferGroupModel()
        {
        }

        public MergeMansionOfferGroupModel(MergeMansionOfferGroupInfo groupInfo)
        {
        }
    }
}