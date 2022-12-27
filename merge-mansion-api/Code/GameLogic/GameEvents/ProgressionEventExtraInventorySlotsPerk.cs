using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    public class ProgressionEventExtraInventorySlotsPerk : ProgressionEventPerk
    {
        [MetaMember(1, 0)]
        public int SlotCount { get; set; }
    }
}
