using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1054)]
    public class DaysLeftActiveMysteryPass : TypedPlayerPropertyId<int>
    {
        private static int FailIndex;
        public override string DisplayName { get; }

        public DaysLeftActiveMysteryPass()
        {
        }
    }
}