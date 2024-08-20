using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1049)]
    public class MysteryMachineCoinsSpentInActiveOrPreviousEvent : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        public MysteryMachineCoinsSpentInActiveOrPreviousEvent()
        {
        }
    }
}