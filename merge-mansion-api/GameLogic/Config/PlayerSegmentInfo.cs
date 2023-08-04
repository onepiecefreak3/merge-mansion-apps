using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    public class PlayerSegmentInfo : PlayerSegmentInfoBase
    {
        public PlayerSegmentInfo()
        {
        }

        public PlayerSegmentInfo(PlayerSegmentId segmentId, PlayerCondition playerCondition, string displayName, string description)
        {
        }
    }
}