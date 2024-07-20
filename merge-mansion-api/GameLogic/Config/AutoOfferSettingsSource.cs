using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core.Offers;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace GameLogic.Config
{
    public class AutoOfferSettingsSource : IConfigItemSource<AutoOfferSettingsInfo, AutoOfferSettingsId>, IGameConfigSourceItem<AutoOfferSettingsId, AutoOfferSettingsInfo>, IHasGameConfigKey<AutoOfferSettingsId>
    {
        private AutoOfferSettingsId OfferId { get; set; }
        private OfferPlacementId Placement { get; set; }
        private bool AutoPromptEnabled { get; set; }
        private MetaDuration AutoPromptCooldown { get; set; }
        private int MaxCount { get; set; }
        private MetaDuration MaxWaitTimerToPrompt { get; set; }
        private List<MetaOfferGroupId> IgnoredOfferGroupIds { get; set; }
        public AutoOfferSettingsId ConfigKey { get; }

        public AutoOfferSettingsSource()
        {
        }
    }
}