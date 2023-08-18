using Metaplay.Core.Model;
using System;
using Metaplay.Core.Serialization;
using Metaplay.Core.GuildDiscovery;

namespace Metaplay.Core.Guild.Messages.Core
{
    [MetaMessage(15210, (MessageDirection)2, false)]
    public class GuildInspectInvitationResponse : MetaMessage
    {
        public int QueryId { get; set; }
        public GuildInspectInvitationResponse.StatusCode Status { get; set; }
        public int InviteId { get; set; }
        public MetaSerialized<GuildDiscoveryInfoBase> GuildDiscoveryInfo { get; set; }
        public MetaSerialized<GuildInviterAvatarBase> InviterAvatar { get; set; }

        private GuildInspectInvitationResponse()
        {
        }

        private GuildInspectInvitationResponse(int queryId, GuildInspectInvitationResponse.StatusCode status, int inviteId, MetaSerialized<GuildDiscoveryInfoBase> guildDiscoveryInfo, MetaSerialized<GuildInviterAvatarBase> inviterAvatar)
        {
        }

        [MetaSerializable]
        public enum StatusCode
        {
            Success = 0,
            InvalidOrExpired = 1,
            RateLimited = 2
        }
    }
}