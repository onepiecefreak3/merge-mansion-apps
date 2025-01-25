using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1058)]
    public class UniqueCardsActiveCardCollection : TypedPlayerPropertyId<int>
    {
        private static int FailIndex;
        public override string DisplayName { get; }

        public UniqueCardsActiveCardCollection()
        {
        }
    }
}