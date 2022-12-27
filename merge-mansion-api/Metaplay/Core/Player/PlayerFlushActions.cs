using System.Collections.Generic;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Player
{
    [MetaMessage(200, MessageDirection.ClientToServer, false)]
    public class PlayerFlushActions : MetaMessage
    {
        public const int MaxTicksPerFlush = 1000;

        public MetaSerialized<List<Operation>> Operations { get; set; } // 0x10
        public uint[] Checksums { get; set; } // 0x20

        public PlayerFlushActions() { }

        public PlayerFlushActions(MetaSerialized<List<Operation>> operation, uint[] checksums)
        {
            Operations = operation;
            Checksums = checksums;
        }

        public struct Operation
        {
            [MetaMember(1, 0)]
            public PlayerActionBase Action { get; set; }
            [MetaMember(2, 0)]
            public int NumSteps { get; set; }
            [MetaMember(3, 0)]
            public int StartTick { get; set; }
            [MetaMember(4, 0)]
            public int OperationIndex { get; set; }
        }
    }
}
