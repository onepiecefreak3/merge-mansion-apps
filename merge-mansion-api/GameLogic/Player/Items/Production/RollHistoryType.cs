using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.GameLogic.Player.Items.Production
{
    public enum RollHistoryType
    {
        None = 0,
        Activation = 1,
        Spawning = 2,
        Decaying = 3,
        Merge = 4,
        Bubble = 5,
        Chest = 6
    }
}
