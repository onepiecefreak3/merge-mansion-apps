using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1043)]
    public class MysteryMachineCoinsSpentInActiveEvent : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        public MysteryMachineCoinsSpentInActiveEvent()
        {
        }
    }
}