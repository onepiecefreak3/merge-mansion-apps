using System;
using System.Collections.Generic;
using Metaplay.Core.Config;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.Rewards;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    public abstract class MetaOfferInfoBase : IGameConfigData<MetaOfferId>, IGameConfigPostLoad, IRefersToMetaOffers
    {
        [MetaMember(100, 0)] public MetaOfferId OfferId { get; set; }
        [MetaMember(101, 0)] public string DisplayName { get; set; }
        [MetaMember(102, 0)] public string Description { get; set; }
        [MetaMember(103, 0)] public MetaRef<InAppProductInfoBase> InAppProduct { get; set; }
        [MetaMember(104, 0)] public List<MetaPlayerRewardBase> Rewards { get; set; }
        [MetaMember(110, 0)] public Nullable<int> MaxActivationsPerPlayer { get; set; }
        [MetaMember(107, 0)] public Nullable<int> MaxPurchasesPerPlayer { get; set; }
        [MetaMember(105, 0)] public Nullable<int> MaxPurchasesPerOfferGroup { get; set; }
        [MetaMember(106, 0)] public Nullable<int> MaxPurchasesPerActivation { get; set; }
        [MetaMember(108, 0)] public List<MetaRef<PlayerSegmentInfoBase>> Segments { get; set; }
        [MetaMember(109, 0)] public List<PlayerCondition> AdditionalConditions { get; set; }
        [MetaMember(111, 0)] public bool IsSticky { get; set; }

        public MetaOfferId ConfigKey => OfferId;

        public void PostLoad()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MetaOfferId> GetReferencedMetaOffers()
        {
            throw new NotImplementedException();
        }
    }
}
