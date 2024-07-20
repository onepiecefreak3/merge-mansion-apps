using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MetaMessage(17600, (MessageDirection)2, true)]
    public class EntityTimelineUpdateMessage : MetaMessage
    {
        [PrettyPrint((PrettyPrintFlag)1)]
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<ModelAction> Operations { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public uint FinalChecksum { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public uint[] DebugChecksums { get; set; }

        private EntityTimelineUpdateMessage()
        {
        }

        public EntityTimelineUpdateMessage(List<ModelAction> operations, int startTick, int startOperation, uint finalChecksum, uint[] debugChecksums)
        {
        }

        public EntityTimelineUpdateMessage(List<ModelAction> operations, uint finalChecksum, uint[] debugChecksums)
        {
        }
    }
}