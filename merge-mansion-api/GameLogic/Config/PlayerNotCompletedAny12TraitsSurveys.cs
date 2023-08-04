using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1025)]
    public class PlayerNotCompletedAny12TraitsSurveys : TypedPlayerPropertyId<bool>
    {
        public override string DisplayName { get; }

        public PlayerNotCompletedAny12TraitsSurveys()
        {
        }
    }
}