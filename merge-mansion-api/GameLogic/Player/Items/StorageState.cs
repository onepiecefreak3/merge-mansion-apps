using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items
{
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
