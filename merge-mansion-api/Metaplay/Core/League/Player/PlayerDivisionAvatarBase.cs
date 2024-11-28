using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.League.Player
{
    [MetaSerializable]
    [PlayerLeaguesEnabledCondition]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    public abstract class PlayerDivisionAvatarBase
    {
        protected PlayerDivisionAvatarBase()
        {
        }

        [PlayerLeaguesEnabledCondition]
        [MetaSerializableDerived(101)]
        public class Default : PlayerDivisionAvatarBase
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string DisplayName;
            private Default()
            {
            }

            public Default(string displayName)
            {
            }
        }
    }
}