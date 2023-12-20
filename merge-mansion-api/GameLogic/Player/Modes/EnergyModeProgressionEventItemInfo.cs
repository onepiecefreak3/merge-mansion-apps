using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Code.GameLogic.Config;
using Metaplay.Core;
using GameLogic.Player.Items;
using Metaplay.Core.Math;

namespace GameLogic.Player.Modes
{
    [MetaSerializable]
    public class EnergyModeProgressionEventItemInfo : IGameConfigData<int>, IGameConfigData, IGameConfigKey<int>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 SpawnChance { get; set; }

        public int ConfigKey => (int)ItemRef.KeyObject;

        public EnergyModeProgressionEventItemInfo()
        {
        }

        public EnergyModeProgressionEventItemInfo(MetaRef<ItemDefinition> itemRef, F32 spawnChance)
        {
        }
    }
}