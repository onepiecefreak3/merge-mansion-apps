using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Player;
using Code.GameLogic.Config;
using System;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class EnergySettingsConfig : IGameConfigData<EnergyType>, IGameConfigData, IHasGameConfigKey<EnergyType>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private EnergyType EnergyType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public long MaxRechargeAmount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaDuration? DefaultUnitRestoreDuration { get; set; }
        public EnergyType ConfigKey => EnergyType;

        public EnergySettingsConfig()
        {
        }

        public EnergySettingsConfig(EnergyType energyType, long maxRechargeAmount, MetaDuration? defaultUnitRestoreDuration)
        {
        }
    }
}