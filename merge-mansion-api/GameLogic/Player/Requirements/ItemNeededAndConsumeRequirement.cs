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
    [MetaSerializableDerived(16)]
    public class ItemNeededAndConsumeRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        private List<ItemType> ItemTypes { get; set; }
        [MetaMember(2, 0)]
        public List<MetaRef<ItemDefinition>> ItemRefs { get; set; }
    }
}
