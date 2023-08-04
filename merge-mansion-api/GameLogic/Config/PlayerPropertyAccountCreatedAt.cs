using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1001)]
    public class PlayerPropertyAccountCreatedAt : TypedPlayerPropertyId<MetaTime>
    {
        public override string DisplayName { get; }

        public PlayerPropertyAccountCreatedAt()
        {
        }
    }
}