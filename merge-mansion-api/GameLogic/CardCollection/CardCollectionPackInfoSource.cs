using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using GameLogic.ConfigPrefabs;

namespace GameLogic.CardCollection
{
    public class CardCollectionPackInfoSource : IConfigItemSource<CardCollectionPackInfo, CardCollectionPackId>, IGameConfigSourceItem<CardCollectionPackId, CardCollectionPackInfo>, IHasGameConfigKey<CardCollectionPackId>
    {
        public CardCollectionPackId ConfigKey { get; set; }
        private int PackStars { get; set; }
        private ConfigAssetPackId AssetPackId { get; set; }
        private string CardPackItem { get; set; }
        private string NameLocId { get; set; }
        private string PocketConversionRewardType { get; set; }
        private string PocketConversionRewardId { get; set; }
        private string PocketConversionRewardAux0 { get; set; }
        private string PocketConversionRewardAux1 { get; set; }
        private int PocketConversionRewardAmount { get; set; }

        public CardCollectionPackInfoSource()
        {
        }
    }
}