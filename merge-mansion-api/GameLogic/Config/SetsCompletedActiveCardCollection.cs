using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1059)]
    public class SetsCompletedActiveCardCollection : TypedPlayerPropertyId<int>
    {
        private static int FailIndex;
        public override string DisplayName { get; }

        public SetsCompletedActiveCardCollection()
        {
        }
    }
}