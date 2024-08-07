using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using GameLogic.GameFeatures;
using System;
using Metaplay.Core.Math;
using Metaplay.Core;

namespace GameLogic.Player.Modes
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 2, 6, 7 })]
    public class EnergyModeInfo : IGameConfigData<PlayerModeId>, IGameConfigData, IHasGameConfigKey<PlayerModeId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerModeId ConfigKey { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int EnergyConsumptionMultiplier { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int CapacityConsumptionMultiplier { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public F32 LevelUpChance { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public CurrencySink CurrencySink { get; set; }

        public EnergyModeInfo()
        {
        }

        public EnergyModeInfo(PlayerModeId configKey, int energyConsumptionMultiplier, int capacityConsumptionMultiplier, F32 levelUpChance, MetaTime activationDate, MetaDuration? durationMaybe)
        {
        }

        public EnergyModeInfo(PlayerModeId configKey, int energyConsumptionMultiplier, int capacityConsumptionMultiplier, F32 levelUpChance)
        {
        }
    }
}