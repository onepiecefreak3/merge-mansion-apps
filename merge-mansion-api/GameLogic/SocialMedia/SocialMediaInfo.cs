using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;

namespace GameLogic.SocialMedia
{
    [MetaSerializable]
    public class SocialMediaInfo : IGameConfigData<SocialMediaId>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SocialMediaId SocialMediaId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public SocialMediaPlatform Type { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool IsEnabled { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string TitleLocalizationId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string SubHeaderLocalizationId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string DescriptionLocalizationId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string ButtonLocalizationId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string Link { get; set; }

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
    }
}