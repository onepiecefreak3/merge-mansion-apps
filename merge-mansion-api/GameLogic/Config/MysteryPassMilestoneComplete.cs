using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1056)]
    public class MysteryPassMilestoneComplete : TypedPlayerPropertyId<int>
    {
        private static int FailIndex;
        public override string DisplayName { get; }

        public MysteryPassMilestoneComplete()
        {
        }
    }
}