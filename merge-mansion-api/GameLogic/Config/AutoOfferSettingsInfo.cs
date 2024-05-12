using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using Metaplay.Core.Offers;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class AutoOfferSettingsInfo : IGameConfigData<AutoOfferSettingsId>, IGameConfigData, IHasGameConfigKey<AutoOfferSettingsId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private AutoOfferSettingsId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private OfferPlacementId Placement { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private bool AutoPromptEnabled { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private MetaDuration AutoPromptCooldown { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private int MaxCount { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaDuration MaxWaitTimerToPrompt { get; set; }
        public AutoOfferSettingsId ConfigKey => Id;

        public AutoOfferSettingsInfo()
        {
        }

        public AutoOfferSettingsInfo(AutoOfferSettingsId id, OfferPlacementId placement, bool autoPromptEnabled, MetaDuration autoPromptCooldown, int maxCount, MetaDuration maxWaitTimerToPrompt)
        {
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<MetaOfferGroupId> IgnoredOfferGroupIds { get; set; }

        public AutoOfferSettingsInfo(AutoOfferSettingsId id, OfferPlacementId placement, bool autoPromptEnabled, MetaDuration autoPromptCooldown, int maxCount, MetaDuration maxWaitTimerToPrompt, List<MetaOfferGroupId> ignoredOfferGroupIds)
        {
        }
    }
}