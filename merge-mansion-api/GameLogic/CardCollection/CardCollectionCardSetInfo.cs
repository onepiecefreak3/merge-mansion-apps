using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.ConfigPrefabs;
using System.Collections.Generic;
using System;
using GameLogic.Player.Rewards;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionCardSetInfo : IGameConfigData<CardCollectionCardSetId>, IGameConfigData, IHasGameConfigKey<CardCollectionCardSetId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionCardSetId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ConfigAssetPackId AssetPackId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<CardCollectionCardId> CardsIds { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        public CardCollectionCardSetInfo()
        {
        }

        public CardCollectionCardSetInfo(CardCollectionCardSetId cardCollectionCardSetId, ConfigAssetPackId configAssetPackId, List<CardCollectionCardId> cardsIds, string nameLocId, List<PlayerReward> rewards)
        {
        }
    }
}