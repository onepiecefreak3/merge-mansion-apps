using Metaplay.Core.Model;
using Metaplay.Core.Serialization;
using System.Collections.Generic;
using System;

namespace Metaplay.Core.Guild.Messages.Core
{
    [MetaMessage(15200, (MessageDirection)2, true)]
    public class GuildTimelineUpdateMessage : MetaMessage
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [PrettyPrint((PrettyPrintFlag)1)]
        public MetaSerialized<List<GuildTimelineUpdateMessage.Operation>> Operations { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public uint FinalChecksum { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int StartTick { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int StartOperation { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int GuildChannelId { get; set; }

        public GuildTimelineUpdateMessage()
        {
        }

        public GuildTimelineUpdateMessage(MetaSerialized<List<GuildTimelineUpdateMessage.Operation>> operations, int startTick, int startOperation, uint finalChecksum, int guildChannelId)
        {
        }

        [MetaSerializable]
        public struct Operation
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public GuildActionBase Action { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public EntityId InvokingPlayerId { get; set; }
        }

        public GuildTimelineUpdateMessage(MetaSerialized<List<GuildTimelineUpdateMessage.Operation>> operations, long startTick, int startOperation, uint finalChecksum, int guildChannelId)
        {
        }
    }
}