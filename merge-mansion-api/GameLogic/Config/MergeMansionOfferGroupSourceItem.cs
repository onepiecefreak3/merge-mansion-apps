using Metaplay.Core.Offers;
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.Config
{
    public class MergeMansionOfferGroupSourceItem : MetaOfferGroupSourceConfigItemBase, IConfigItemSource<MergeMansionOfferGroupInfo, MetaOfferGroupId>, IGameConfigSourceItem<MetaOfferGroupId, MergeMansionOfferGroupInfo>, IHasGameConfigKey<MetaOfferGroupId>
    {
        private string TitleLocId { get; set; }
        private string OfferTitlePrefabId { get; set; }
        private string BackgroundPrefabId { get; set; }
        private string OfferButtonPrefabId { get; set; }
        private string OfferContainerPrefabId { get; set; }
        private int FlashSaleWeight { get; set; }
        private OfferPlacementId[] AdditionalPlacements { get; set; }
        private bool DynamicContent { get; set; }
        private bool IsUnderMore { get; set; }
        public MetaOfferGroupId ConfigKey { get; }

        public MergeMansionOfferGroupSourceItem()
        {
        }

        private string DescriptionLocId { get; set; }
        private ManuallyActivatedOfferGroupId ManualActivationInfo { get; set; }
        private List<OfferPopupTriggerId> OfferPopupTriggers { get; set; }
        private int? MaxPurchasesPerActivation { get; set; }
    }
}