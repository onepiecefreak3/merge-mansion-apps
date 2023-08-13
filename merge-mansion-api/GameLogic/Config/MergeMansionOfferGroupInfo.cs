using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System;
using System.Collections.Generic;
using Metaplay.Core.Activables;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    [MetaActivableConfigData("OfferGroup", false)]
    public class MergeMansionOfferGroupInfo : MetaOfferGroupInfoBase, IOfferGroupVisuals
    {
        [MetaMember(1, 0)]
        private string OfferTitlePrefabId { get; set; }

        [MetaMember(2, 0)]
        private string BackgroundPrefabId { get; set; }

        [MetaMember(3, 0)]
        private string TitleLocId { get; set; }

        [MetaMember(4, 0)]
        private string OfferButtonPrefabId { get; set; }

        [MetaMember(5, 0)]
        private string OfferContainerPrefabId { get; set; }

        [MetaMember(6, 0)]
        private int FlashSaleWeight { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        private bool DynamicContent { get; set; }
        public string OfferTitleId { get; }
        public string BackgroundId { get; }
        public string GroupTitleLocId { get; }
        public string ButtonId { get; }
        public string ContainerId { get; }
        public int FlashSaleWeightAmount { get; }
        public bool IsDynamicContent { get; }

        public MergeMansionOfferGroupInfo()
        {
        }

        public MergeMansionOfferGroupInfo(MetaOfferGroupSourceConfigItemBase source, string titleLocId, string offerTitlePrefabId, string backgroundPrefabId, string offerButtonPrefabId, string offerContainerPrefabId, int flashSaleWeight, bool dynamicContent)
        {
        }

        [MetaMember(8, (MetaMemberFlags)0)]
        private OfferPlacementId[] AdditionalPlacements { get; set; }
        public IEnumerable<OfferPlacementId> AdditionalPlacementsForOffer { get; }

        public MergeMansionOfferGroupInfo(MetaOfferGroupSourceConfigItemBase source, string titleLocId, string offerTitlePrefabId, string backgroundPrefabId, string offerButtonPrefabId, string offerContainerPrefabId, int flashSaleWeight, bool dynamicContent, OfferPlacementId[] additionalPlacements)
        {
        }
    }
}