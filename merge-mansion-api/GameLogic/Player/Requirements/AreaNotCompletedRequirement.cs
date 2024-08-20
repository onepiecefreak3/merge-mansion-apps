using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Area;
using System.Runtime.Serialization;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(47)]
    public class AreaNotCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<AreaInfo> AreaRef { get; set; }

        [IgnoreDataMember]
        public AreaInfo Area { get; }

        private AreaNotCompletedRequirement()
        {
        }

        public AreaNotCompletedRequirement(AreaId id)
        {
        }
    }
}