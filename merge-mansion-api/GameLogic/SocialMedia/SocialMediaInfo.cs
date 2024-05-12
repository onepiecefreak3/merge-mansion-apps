using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;
using Metaplay.Core.Localization;

namespace GameLogic.SocialMedia
{
    [MetaSerializable]
    public class SocialMediaInfo : IGameConfigData<SocialMediaId>, IGameConfigData, IHasGameConfigKey<SocialMediaId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SocialMediaId SocialMediaId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public SocialMediaPlatform Type { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string TitleLocalizationId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string SubHeaderLocalizationId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string DescriptionLocalizationId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string ButtonLocalizationId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<PlayerRequirement> Requirements { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }
        public SocialMediaId ConfigKey => SocialMediaId;

        public SocialMediaInfo()
        {
        }

        public SocialMediaInfo(SocialMediaId configKey, SocialMediaPlatform type, bool isEnabled, string titleLocalizationId, string subHeaderLocalizationId, string descriptionLocalizationId, string buttonLocalizationId, string link, List<PlayerRequirement> requirements, List<PlayerReward> rewards)
        {
        }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool ShowPopup { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public bool ShowSettingsButton { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string LinkLocalizationId { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public List<LanguageId> BlacklistedLanguageIDs { get; set; }

        public SocialMediaInfo(SocialMediaId configKey, SocialMediaPlatform type, bool showPopup, bool showSettingsButton, string titleLocalizationId, string subHeaderLocalizationId, string descriptionLocalizationId, string buttonLocalizationId, string linkLocalizationId, List<PlayerRequirement> requirements, List<PlayerReward> rewards, List<LanguageId> blacklistedLanguageIDs)
        {
        }
    }
}