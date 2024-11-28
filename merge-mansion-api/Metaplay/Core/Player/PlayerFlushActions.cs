using System.Collections.Generic;
using Metaplay.Core.Model;
using Metaplay.Core.Serialization;
using System;

namespace Metaplay.Core.Player
{
    [MetaMessage(200, MessageDirection.ClientToServer, false)]
    public class PlayerFlushActions : MetaMessage
    {
        public const int MaxTicksPerFlush = 1000;
        public MetaSerialized<List<Operation>> Operations { get; set; } // 0x10
        public uint[] Checksums { get; set; } // 0x20

        public PlayerFlushActions()
        {
        }

        public PlayerFlushActions(MetaSerialized<List<Operation>> operation, uint[] checksums)
        {
            Operations = operation;
            Checksums = checksums;
        }

        [MetaSerializable]
        public struct Operation
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public PlayerActionBase Action { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public int NumSteps { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            public long StartTick { get; set; }

            [MetaMember(4, (MetaMemberFlags)0)]
            public int OperationIndex { get; set; }
        }
    }
}