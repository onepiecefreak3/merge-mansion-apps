using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System;
using System.Collections.Generic;
using Metaplay.Core.Activables;
using Code.GameLogic.Config;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaActivableConfigData("OfferGroup", false, true)]
    [MetaBlockedMembers(new int[] { 10 })]
    [MetaSerializableDerived(1)]
    public class MergeMansionOfferGroupInfo : MetaOfferGroupInfoBase, IOfferGroupVisuals, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private string OfferTitlePrefabId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private string BackgroundPrefabId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private string TitleLocId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private string OfferButtonPrefabId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private string OfferContainerPrefabId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
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

        [MetaMember(13, (MetaMemberFlags)0)]
        public int? MaxPurchasesPerActivation { get; set; }
        public bool CanEndBeforeExpiration { get; }

        public MergeMansionOfferGroupInfo(MetaOfferGroupSourceConfigItemBase source, string titleLocId, string descriptionLocId, string offerTitlePrefabId, string backgroundPrefabId, string offerButtonPrefabId, string offerContainerPrefabId, int flashSaleWeight, bool dynamicContent, OfferPlacementId[] additionalPlacements, bool isUnderMore, ManuallyActivatedOfferGroupId manualActivationId, List<OfferPopupTriggerId> offerPopupTriggerIds, int? maxPurchasesPerActivation)
        {
        }

        [MetaMember(14, (MetaMemberFlags)0)]
        public MetaDuration? OfferPopupTriggerCooldown { get; set; }
        public bool ActivatesOnTrigger { get; }

        public MergeMansionOfferGroupInfo(MetaOfferGroupSourceConfigItemBase source, string titleLocId, string descriptionLocId, string offerTitlePrefabId, string backgroundPrefabId, string offerButtonPrefabId, string offerContainerPrefabId, int flashSaleWeight, bool dynamicContent, OfferPlacementId[] additionalPlacements, bool isUnderMore, List<MetaRef<OfferPopupTrigger>> offerPopupTriggers, int? maxPurchasesPerActivation, MetaDuration? offerPopupTriggerCooldown)
        {
        }
    }
}