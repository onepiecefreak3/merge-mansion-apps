using Metaplay.Core.Model;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1048)]
    public class PlayerPropertyMergeGoalNotCompleted : PlayerPropertyMatcher<HotspotId>
    {
        public override string DisplayName { get; }

        public PlayerPropertyMergeGoalNotCompleted()
        {
        }
    }
}