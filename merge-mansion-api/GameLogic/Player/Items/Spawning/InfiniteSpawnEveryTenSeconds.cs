using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Spawning
{
    [MetaSerializableDerived(2)]
    public class InfiniteSpawnEveryTenSeconds : ISpawnCycle
    {
    }
}
