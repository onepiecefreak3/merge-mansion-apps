using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1026)]
    public class PlayerNotReceivedAny12TraitsSurveys : TypedPlayerPropertyId<bool>
    {
        public override string DisplayName { get; }

        public PlayerNotReceivedAny12TraitsSurveys()
        {
        }
    }
}