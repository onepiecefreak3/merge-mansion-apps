using Metaplay.Core.Model;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1007)]
    public class PlayerPropertyMergeGoalCompleted : PlayerPropertyMatcher<HotspotId>
    {
        public override string DisplayName => $"Has merge goal {_value} completed";

        public PlayerPropertyMergeGoalCompleted()
        {
        }
    }
}