using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity.Messages;
using System;

namespace Metaplay.Core.Guild.Messages.Core
{
    [MetaMessage(15206, (MessageDirection)2, false)]
    public class GuildViewResponse : MetaMessage
    {
        public GuildViewResponse.StatusCode Status { get; set; }
        public EntitySerializedState GuildState { get; set; }
        public int GuildChannelId { get; set; }
        public int QueryId { get; set; }

        private GuildViewResponse()
        {
        }

        public GuildViewResponse(GuildViewResponse.StatusCode status, EntitySerializedState guildState, int guildChannelId, int queryId)
        {
        }

        [MetaSerializable]
        public enum StatusCode
        {
            Success = 0,
            Refused = 1
        }
    }
}