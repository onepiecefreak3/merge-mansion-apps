using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Guild.Messages.Core
{
    [MetaMessage(15209, (MessageDirection)2, false)]
    public class GuildCreateInvitationResponse : MetaMessage
    {
        public int QueryId { get; set; }
        public GuildCreateInvitationResponse.StatusCode Status { get; set; }
        public int InviteId { get; set; }

        private GuildCreateInvitationResponse()
        {
        }

        private GuildCreateInvitationResponse(int queryId, GuildCreateInvitationResponse.StatusCode status, int inviteId)
        {
        }

        [MetaSerializable]
        public enum StatusCode
        {
            Success = 0,
            NotAMember = 1,
            NotAllowed = 2,
            TooManyInvites = 3,
            RateLimited = 4
        }
    }
}