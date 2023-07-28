using Metaplay.Core.Model;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public sealed class StorageState
    {
        [MetaMember(1, 0)]
        internal int currentAmount { get; set; } // 0x10

        public StorageState(StorageState container1, StorageState container2)
        {
            currentAmount = (container1?.currentAmount ?? 0) + (container2?.currentAmount ?? 0);
        }

        public bool IsFull(int maxLimit)
        {
            return maxLimit <= currentAmount;
        }
    }
}
