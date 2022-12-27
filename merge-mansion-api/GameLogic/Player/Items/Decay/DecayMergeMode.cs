using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.GameLogic.Player.Items.Decay
{
    public enum DecayMergeMode
    {
        Reset = 0,
        Min = 1,
        Average = 2,
        Max = 3,
        Sum = 4
    }
}
