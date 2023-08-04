using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1028)]
    public class PlayerTimeSinceLastPurchaseDays : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        public PlayerTimeSinceLastPurchaseDays()
        {
        }
    }
}