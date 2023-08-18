using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild.Messages.Core
{
    [MessageRoutingRuleSession]
    [MetaMessage(15303, (MessageDirection)1, false)]
    public class GuildJoinRequest : MetaMessage
    {
        public GuildJoinRequest.JoinMode Mode { get; set; }
        public EntityId GuildId { get; set; }
        public int InviteId { get; set; }
        public GuildInviteCode InviteCode { get; set; }

        private GuildJoinRequest()
        {
        }

        public GuildJoinRequest(GuildJoinRequest.JoinMode mode, EntityId guildId, int inviteId, GuildInviteCode inviteCode)
        {
        }

        [MetaSerializable]
        public enum JoinMode
        {
            Normal = 0,
            InviteCode = 1
        }
    }
}