using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public struct MysteryMachineContainerItemData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public IMysteryMachineItem Item;
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime OriginalSpawnTime;
    }
}