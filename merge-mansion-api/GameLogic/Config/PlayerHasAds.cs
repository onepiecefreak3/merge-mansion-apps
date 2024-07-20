using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1046)]
    public class PlayerHasAds : TypedPlayerPropertyId<bool>
    {
        public override string DisplayName { get; }

        public PlayerHasAds()
        {
        }
    }
}