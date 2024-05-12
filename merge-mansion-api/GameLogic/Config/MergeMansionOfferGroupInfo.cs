using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System;
using System.Collections.Generic;
using Metaplay.Core.Activables;
using Code.GameLogic.Config;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    [MetaActivableConfigData("OfferGroup", false)]
    public class MergeMansionOfferGroupInfo : MetaOfferGroupInfoBase, IOfferGroupVisuals, IValidatable
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

        [MetaMember(9, (MetaMemberFlags)0)]
        public bool IsUnderMore { get; set; }

        public MergeMansionOfferGroupInfo(MetaOfferGroupSourceConfigItemBase source, string titleLocId, string offerTitlePrefabId, string backgroundPrefabId, string offerButtonPrefabId, string offerContainerPrefabId, int flashSaleWeight, bool dynamicContent, OfferPlacementId[] additionalPlacements, bool isUnderMore)
        {
        }

        [MetaMember(10, (MetaMemberFlags)0)]
        public MetaRef<ManuallyActivatedOfferGroupInfo> ManualActivationInfo { get; set; }

        public MergeMansionOfferGroupInfo(MetaOfferGroupSourceConfigItemBase source, string titleLocId, string offerTitlePrefabId, string backgroundPrefabId, string offerButtonPrefabId, string offerContainerPrefabId, int flashSaleWeight, bool dynamicContent, OfferPlacementId[] additionalPlacements, bool isUnderMore, ManuallyActivatedOfferGroupId manualActivationId)
        {
        }

        [MetaMember(11, (MetaMemberFlags)0)]
        public List<MetaRef<OfferPopupTrigger>> OfferPopupTriggers { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        private string DescriptionLocId { get; set; }
        public string GroupDescriptionLocId { get; }

        public MergeMansionOfferGroupInfo(MetaOfferGroupSourceConfigItemBase source, string titleLocId, string descriptionLocId, string offerTitlePrefabId, string backgroundPrefabId, string offerButtonPrefabId, string offerContainerPrefabId, int flashSaleWeight, bool dynamicContent, OfferPlacementId[] additionalPlacements, bool isUnderMore, ManuallyActivatedOfferGroupId manualActivationId, List<OfferPopupTriggerId> offerPopupTriggerIds)
        {
        }
    }
}