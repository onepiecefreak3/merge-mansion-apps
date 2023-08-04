using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1012)]
    public class PlayerPropertyAssociationIdGroup : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        public PlayerPropertyAssociationIdGroup()
        {
        }
    }
}