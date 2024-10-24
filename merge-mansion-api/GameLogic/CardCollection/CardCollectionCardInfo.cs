using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.ConfigPrefabs;
using System;
using Metaplay.Core;
using GameLogic.Player.Items;
using System.Runtime.Serialization;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionCardInfo : IGameConfigData<CardCollectionCardId>, IGameConfigData, IHasGameConfigKey<CardCollectionCardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionCardId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ConfigAssetPackId AssetPackId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public CardStars Stars { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsSpecial { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> CardItemRef { get; set; }

        [IgnoreDataMember]
        public bool IsWildCard { get; }

        public CardCollectionCardInfo()
        {
        }

        public CardCollectionCardInfo(CardCollectionCardId cardCollectionCardId, ConfigAssetPackId configAssetPackId, CardStars stars, string nameLocId, bool isSpecial, MetaRef<ItemDefinition> cardItemRef)
        {
        }
    }
}