using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core.Localization;

namespace GameLogic.SocialMedia
{
    public class SocialMediaSource : IConfigItemSource<SocialMediaInfo, SocialMediaId>, IGameConfigSourceItem<SocialMediaId, SocialMediaInfo>, IHasGameConfigKey<SocialMediaId>
    {
        public SocialMediaId ConfigKey { get; set; }
        public SocialMediaPlatform Type { get; set; }
        public bool ShowPopup { get; set; }
        public bool ShowSettingsButton { get; set; }
        public string TitleLocalizationId { get; set; }
        public string SubHeaderLocalizationId { get; set; }
        public string DescriptionLocalizationId { get; set; }
        public string ButtonLocalizationId { get; set; }
        public string LinkLocalizationId { get; set; }
        public List<string> RequirementType { get; set; }
        public List<string> RequirementId { get; set; }
        public List<string> RequirementAmount { get; set; }
        public List<string> RequirementAux0 { get; set; }
        public List<string> RewardType { get; set; }
        public List<string> RewardId { get; set; }
        public List<int> RewardAmount { get; set; }
        public List<string> RewardAux0 { get; set; }
        public List<string> RewardAux1 { get; set; }
        public List<LanguageId> BlacklistedLanguageIDs { get; set; }

        public SocialMediaSource()
        {
        }
    }
}