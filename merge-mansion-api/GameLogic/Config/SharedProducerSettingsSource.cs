using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    public class SharedProducerSettingsSource : IConfigItemSource<SharedProducerSettings, SharedProducerSettingsId>, IGameConfigSourceItem<SharedProducerSettingsId, SharedProducerSettings>, IHasGameConfigKey<SharedProducerSettingsId>
    {
        public SharedProducerSettingsId ConfigKey { get; set; }
        private List<PlayerSegmentId> Segment { get; set; }
        private List<int> Value { get; set; }

        public SharedProducerSettingsSource()
        {
        }
    }
}