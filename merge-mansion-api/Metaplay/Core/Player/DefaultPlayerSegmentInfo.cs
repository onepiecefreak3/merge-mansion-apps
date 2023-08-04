using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(100)]
    public class DefaultPlayerSegmentInfo : PlayerSegmentInfoBase
    {
        public DefaultPlayerSegmentInfo()
        {
        }

        public DefaultPlayerSegmentInfo(PlayerSegmentId segmentId, PlayerCondition playerCondition, string displayName, string description)
        {
        }
    }
}