using System;

namespace Metaplay.Core.League.Player
{
    public class PlayerLeaguesEnabledCondition : MetaplayFeatureEnabledConditionAttribute
    {
        public override bool IsEnabled { get; }

        public PlayerLeaguesEnabledCondition()
        {
        }
    }
}