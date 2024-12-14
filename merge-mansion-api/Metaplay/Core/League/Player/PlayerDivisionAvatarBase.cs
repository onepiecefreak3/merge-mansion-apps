using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.League.Player
{
    [PlayerLeaguesEnabledCondition]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [MetaSerializable]
    public abstract class PlayerDivisionAvatarBase
    {
        protected PlayerDivisionAvatarBase()
        {
        }

        [MetaSerializableDerived(101)]
        [PlayerLeaguesEnabledCondition]
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