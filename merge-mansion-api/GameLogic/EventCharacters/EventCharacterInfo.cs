using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using GameLogic.ConfigPrefabs;
using GameLogic.Story;
using Metaplay.Core;
using GameLogic.Player.Items;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace GameLogic.EventCharacters
{
    [MetaSerializable]
    public class EventCharacterInfo : IGameConfigData<EventCharacterId>, IGameConfigData, IHasGameConfigKey<EventCharacterId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventCharacterId EventCharacterId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public ConfigAssetPackId AssetPackId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string DescLocId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public StoryDefinitionId DialogueOnUnlock { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemToForcePurchaseOnUnlockRef { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<PlayerReward> RewardsOnUnlock { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public string EndPopupSubHeaderLocId { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public string EndPopupDescriptionLocId { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public string EndPopupRewardsLocId { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public string StartPopupSubHeaderLocId { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public string StartPopupDescriptionLocId { get; set; }
        public EventCharacterId ConfigKey => EventCharacterId;

        public EventCharacterInfo()
        {
        }

        public EventCharacterInfo(EventCharacterId eventCharacterId, string displayName, string description, ConfigAssetPackId assetPackId, string nameLocId, string descLocId, StoryDefinitionId dialogueOnUnlock, MetaRef<ItemDefinition> itemToForcePurchaseOnUnlockRef, List<PlayerReward> rewardsOnUnlock, string endPopupSubHeaderLocId, string endPopupDescriptionLocId, string endPopupRewardsLocId, string startPopupSubHeaderLocId, string startPopupDescriptionLocId)
        {
        }
    }
}