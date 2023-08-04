using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1017)]
    public class PlayerHasAnRequirementForAnItem : TypedPlayerPropertyId<bool>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int RequiredItem { get; set; }
        public override string DisplayName { get; }

        public PlayerHasAnRequirementForAnItem()
        {
        }

        public PlayerHasAnRequirementForAnItem(int requiredItem)
        {
        }
    }
}