using System;

namespace Metaplay.Core.League
{
    public class LeaguesEnabledCondition : MetaplayFeatureEnabledConditionAttribute
    {
        public override bool IsEnabled { get; }

        public LeaguesEnabledCondition()
        {
        }
    }
}