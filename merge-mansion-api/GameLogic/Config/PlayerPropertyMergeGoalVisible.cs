using Metaplay.Core.Model;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1008)]
    public class PlayerPropertyMergeGoalVisible : PlayerPropertyMatcher<HotspotId>
    {
        public override string DisplayName => $"Has merge goal {_value} visible";

        public PlayerPropertyMergeGoalVisible()
        {
        }
    }
}