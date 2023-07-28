using GameLogic.Merge;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
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
