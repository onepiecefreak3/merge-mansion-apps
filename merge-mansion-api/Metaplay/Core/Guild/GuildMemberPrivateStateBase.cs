using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Guild
{
    [MetaSerializableDerived(100)]
    public class GuildMemberPrivateStateBase : MultiplayerMemberPrivateStateBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<int, GuildInviteState> Invites { get; set; }

        private GuildMemberPrivateStateBase()
        {
        }

        public GuildMemberPrivateStateBase(EntityId memberPlayerId, IGuildModelBase model)
        {
        }
    }
}