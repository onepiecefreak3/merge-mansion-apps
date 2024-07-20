using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Math;
using Metaplay.Core;

namespace GameLogic.Player.Modes
{
    public class EnergyModeSource : IConfigItemSource<EnergyModeInfo, PlayerModeId>, IGameConfigSourceItem<PlayerModeId, EnergyModeInfo>, IHasGameConfigKey<PlayerModeId>
    {
        public PlayerModeId ConfigKey { get; set; }
        private int EnergyConsumptionMultiplier { get; set; }
        private int CapacityConsumptionMultiplier { get; set; }
        private F32 LevelUpChance { get; set; }
        private MetaTime ActivationDate { get; set; }
        private MetaDuration? Duration { get; set; }

        public EnergyModeSource()
        {
        }
    }
}