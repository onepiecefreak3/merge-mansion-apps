using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Config
{
    [MetaSerializableDerived(14)]
    public class MergeMansionOfferGroupModel : MetaOfferGroupModelBase
    {
        public MergeMansionOfferGroupModel()
        {
        }

        public MergeMansionOfferGroupModel(MergeMansionOfferGroupInfo groupInfo)
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        public bool PendingActivationTrigger { get; set; }
    }
}