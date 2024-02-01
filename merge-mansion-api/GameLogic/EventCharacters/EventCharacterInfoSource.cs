using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using GameLogic.ConfigPrefabs;
using GameLogic.Story;
using System.Collections.Generic;

namespace GameLogic.EventCharacters
{
    public class EventCharacterInfoSource : IConfigItemSource<EventCharacterInfo, EventCharacterId>, IGameConfigSourceItem<EventCharacterId, EventCharacterInfo>, IGameConfigKey<EventCharacterId>
    {
        private EventCharacterId EventCharacterId { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private ConfigAssetPackId AssetPackId { get; set; }
        private string NameLocId { get; set; }
        private string DescLocId { get; set; }
        private StoryDefinitionId DialogueOnUnlock { get; set; }
        private string ItemToForcePurchaseOnUnlock { get; set; }
        private List<string> RewardTypeOnUnlock { get; set; }
        private List<string> RewardIdOnUnlock { get; set; }
        private List<string> RewardAux0OnUnlock { get; set; }
        private List<string> RewardAux1OnUnlock { get; set; }
        private List<int> RewardAmountOnUnlock { get; set; }
        private string EndPopupSubHeaderLocId { get; set; }
        private string EndPopupDescriptionLocId { get; set; }
        private string EndPopupRewardsLocId { get; set; }
        private string StartPopupSubHeaderLocId { get; set; }
        private string StartPopupDescriptionLocId { get; set; }
        public EventCharacterId ConfigKey { get; }

        public EventCharacterInfoSource()
        {
        }
    }
}