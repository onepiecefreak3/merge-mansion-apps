using Metaplay.Core.Model;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1057)]
    public class MysteryPassMilestoneNotComplete : PlayerPropertyMatcher<string>
    {
        public override string DisplayName { get; }

        public MysteryPassMilestoneNotComplete()
        {
        }
    }
}