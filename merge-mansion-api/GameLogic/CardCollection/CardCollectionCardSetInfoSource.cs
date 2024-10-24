using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.ConfigPrefabs;
using System.Collections.Generic;
using System;

namespace GameLogic.CardCollection
{
    public class CardCollectionCardSetInfoSource : IConfigItemSource<CardCollectionCardSetInfo, CardCollectionCardSetId>, IGameConfigSourceItem<CardCollectionCardSetId, CardCollectionCardSetInfo>, IHasGameConfigKey<CardCollectionCardSetId>
    {
        public CardCollectionCardSetId ConfigKey { get; set; }
        private ConfigAssetPackId AssetPackId { get; set; }
        private List<CardCollectionCardId> CardsIds { get; set; }
        private string NameLocId { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }

        public CardCollectionCardSetInfoSource()
        {
        }
    }
}