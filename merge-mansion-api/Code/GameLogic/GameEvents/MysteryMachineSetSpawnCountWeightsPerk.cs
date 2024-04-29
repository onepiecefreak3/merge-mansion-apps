using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(3)]
    public class MysteryMachineSetSpawnCountWeightsPerk : IMysteryMachinePerk
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<int> SpawnCountWeights { get; set; }

        private MysteryMachineSetSpawnCountWeightsPerk()
        {
        }

        public MysteryMachineSetSpawnCountWeightsPerk(List<int> spawnCountWeights)
        {
        }
    }
}