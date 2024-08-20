using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Client
{
    [MetaSerializable]
    public class ClientSlotCore : ClientSlot
    {
        public static readonly ClientSlot Player = new ClientSlotCore(1, "Player"); // 0x0
        public static readonly ClientSlot Guild = new ClientSlotCore(2, "Guild"); // 0x8
        public ClientSlotCore(int id, string name) : base(id, name)
        {
        }

        public static ClientSlot Nft;
        [Obsolete("Create a game-specific client slot instead.")]
        public static ClientSlot PlayerDivisionLegacy;
    }
}