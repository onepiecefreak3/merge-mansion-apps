using Code.GameLogic.Config;
using GameLogic.Player;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;

namespace GameLogic.Config
{
    public class EnergySettingsConfigSource : IConfigItemSource<EnergySettingsConfig, EnergyType>, IGameConfigSourceItem<EnergyType, EnergySettingsConfig>, IHasGameConfigKey<EnergyType>
    {
        public EnergyType ConfigKey { get; set; }
        public long MaxRechargeAmount { get; set; }
        public MetaDuration? DefaultUnitRestoreDuration { get; set; }

        public EnergySettingsConfigSource()
        {
        }
    }
}