using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1020)]
    public class PlayerSessionsInLastNDays : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int Days { get; set; }
        public override string DisplayName { get; }

        public PlayerSessionsInLastNDays()
        {
        }

        public PlayerSessionsInLastNDays(int days)
        {
        }
    }
}