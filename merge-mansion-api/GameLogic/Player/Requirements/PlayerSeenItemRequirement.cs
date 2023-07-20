using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Player.Items;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(7)]
    [MetaSerializable]
    public class PlayerSeenItemRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }
        [MetaMember(2, 0)]
        public int Requirement { get; set; }
    }
}
