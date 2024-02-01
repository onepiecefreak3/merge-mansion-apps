using Metaplay.Core.Offers;
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    public class MergeMansionOfferGroupSourceItem : MetaOfferGroupSourceConfigItemBase, IConfigItemSource<MergeMansionOfferGroupInfo, MetaOfferGroupId>, IGameConfigSourceItem<MetaOfferGroupId, MergeMansionOfferGroupInfo>, IGameConfigKey<MetaOfferGroupId>
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
    }
}