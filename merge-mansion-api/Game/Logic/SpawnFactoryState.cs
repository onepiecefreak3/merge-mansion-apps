using System.Collections.Generic;
using Metaplay.Core.Model;

namespace Game.Logic
{
    [MetaSerializable]
    public class SpawnFactoryState
    {
        [MetaMember(1, 0)]
        private Dictionary<string, int> currentSpawnIndex; // 0x10
        public int GetIndexOf(string id)
        {
            if (currentSpawnIndex.ContainsKey(id))
                return currentSpawnIndex[id];
            return 0;
        }

        public void IncreaseIndexOf(string id)
        {
            if (!currentSpawnIndex.ContainsKey(id))
                currentSpawnIndex[id] = 0;
            currentSpawnIndex[id]++;
        }

        public SpawnFactoryState()
        {
        }
    }
}