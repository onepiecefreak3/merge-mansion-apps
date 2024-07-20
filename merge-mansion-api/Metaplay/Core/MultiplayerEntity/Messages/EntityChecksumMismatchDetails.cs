using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.MultiplayerEntity.Messages
{
    [MessageRoutingRuleEntityChannel]
    [MetaMessage(17503, (MessageDirection)1, true)]
    public class EntityChecksumMismatchDetails : MetaMessage
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public byte[] ChecksumBuffer;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Tick;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int Operation;
        private EntityChecksumMismatchDetails()
        {
        }

        public EntityChecksumMismatchDetails(byte[] checksumBuffer, int tick, int operation)
        {
        }
    }
}