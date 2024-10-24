using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using GameLogic.ConfigPrefabs;
using Metaplay.Core;
using GameLogic.Player.Items;
using GameLogic.Player.Rewards;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionPackInfo : IGameConfigData<CardCollectionPackId>, IGameConfigData, IHasGameConfigKey<CardCollectionPackId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionPackId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int PackStars { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public ConfigAssetPackId AssetPackId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> CardPackItemRef { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public PlayerReward PocketConversionReward { get; set; }

        public CardCollectionPackInfo()
        {
        }

        public CardCollectionPackInfo(CardCollectionPackId cardCollectionPackId, int packStars, ConfigAssetPackId configAssetPackId, MetaRef<ItemDefinition> cardPackItemRef, string nameLocId, PlayerReward pocketConversionReward)
        {
        }
    }
}