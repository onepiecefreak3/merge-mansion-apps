using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class ProgressionEventFreeShopItemPerk : ProgressionEventPerk
    {
        [MetaMember(1, 0)]
        public ShopItemId ShopItemId { get; set; }
        [MetaMember(2, 0)]
        public MetaDuration Interval { get; set; }
    }
}
