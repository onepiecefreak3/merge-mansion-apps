using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Spawning
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
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
