using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class SharedProducerSettings : IGameConfigData<SharedProducerSettingsId>, IGameConfigData, IHasGameConfigKey<SharedProducerSettingsId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private SharedProducerSettingsId SettingsId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<ValueTuple<PlayerSegmentId, int>> Overrides { get; set; }
        public SharedProducerSettingsId ConfigKey => SettingsId;

        public SharedProducerSettings()
        {
        }

        public SharedProducerSettings(SharedProducerSettingsId settingsId, List<ValueTuple<PlayerSegmentId, int>> overrides)
        {
        }
    }
}