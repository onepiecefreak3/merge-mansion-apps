using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Spawning
{
    [MetaSerializableDerived(1)]
    public class SpawnCycle : ISpawnCycle
    {
        [MetaMember(1)]
        public MetaDuration SpawnDelay { get; set; }
        [MetaMember(2)]
        public MetaDuration FirstCycleStartDelay { get; set; }
        [MetaMember(3)]
        public MetaDuration DelayBetweenCycles { get; set; }
        [MetaMember(4)]
        public int HowManyAreGeneratedPerSpawn { get; set; }
        [MetaMember(5)]
        public int SpawnAmountInCycle { get; set; }
        [MetaMember(6)]
        public int HowManyCycles { get; set; }
	}
}
