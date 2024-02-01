using Metaplay.Core.Model;
using System.Collections.Generic;

namespace GameLogic.Player.Items.OverrideSpawnChance
{
    [MetaSerializable]
    public class OverrideSpawnChanceFeatures
    {
        public static OverrideSpawnChanceFeatures NoOverrideSpawnChance;
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<OverrideSpawnChance> OverrideSpawnChances { get; set; }

        public OverrideSpawnChanceFeatures(List<OverrideSpawnChance> overrideSpawnChances)
        {
        }

        private OverrideSpawnChanceFeatures()
        {
        }
    }
}