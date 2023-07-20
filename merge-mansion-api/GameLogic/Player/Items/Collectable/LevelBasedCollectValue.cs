using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    // Namespace: GameLogic.Player.Items.Collectable
    [MetaSerializableDerived(1)]
    // Namespace: GameLogic.Player.Items.Collectable
    [MetaSerializable]
    public class LevelBasedCollectValue : ICalculateCollectValue
    {
        [MetaMember(1, 0)]
        public int Factor { get; set; }
        [MetaMember(2, 0)]
        public Currencies Currency { get; set; }
    }
}
