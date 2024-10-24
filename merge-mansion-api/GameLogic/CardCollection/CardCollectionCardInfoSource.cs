using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.ConfigPrefabs;
using System;

namespace GameLogic.CardCollection
{
    public class CardCollectionCardInfoSource : IConfigItemSource<CardCollectionCardInfo, CardCollectionCardId>, IGameConfigSourceItem<CardCollectionCardId, CardCollectionCardInfo>, IHasGameConfigKey<CardCollectionCardId>
    {
        public CardCollectionCardId ConfigKey { get; set; }
        private ConfigAssetPackId AssetPackId { get; set; }
        private CardStars CardStars { get; set; }
        private string NameLocId { get; set; }
        private bool IsSpecial { get; set; }
        private string CardItem { get; set; }

        public CardCollectionCardInfoSource()
        {
        }
    }
}