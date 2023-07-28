using GameLogic.Area;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(10)]
    [MetaSerializable]
    public class AreaCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public MetaRef<AreaInfo> AreaRef { get; set; }
    }
}
