using System;

namespace Metaplay.Core.Guild
{
    public class GuildsEnabledCondition : MetaplayFeatureEnabledConditionAttribute
    {
        public override bool IsEnabled { get; }

        public GuildsEnabledCondition()
        {
        }
    }
}