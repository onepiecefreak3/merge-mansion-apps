using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Merge;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoardCell
    {
        [MetaMember(1, 0)]
        public ItemTypeConstant ItemType { get; set; }
        [MetaMember(2, 0)]
        public ItemVisibility ItemVisibility { get; set; }
    }
}
