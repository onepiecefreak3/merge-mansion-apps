using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MetaMessage(17603, (MessageDirection)2, false)]
    public class EntityTimelinePingTraceMarker : MetaMessage
    {
        public uint Id { get; set; }
        public EntityTimelinePingTraceMarker.TracePosition Position { get; set; }

        private EntityTimelinePingTraceMarker()
        {
        }

        public EntityTimelinePingTraceMarker(uint id, EntityTimelinePingTraceMarker.TracePosition position)
        {
        }

        [MetaSerializable]
        public enum TracePosition
        {
            MessageReceivedOnEntity = 0,
            AfterNextTick = 1
        }
    }
}