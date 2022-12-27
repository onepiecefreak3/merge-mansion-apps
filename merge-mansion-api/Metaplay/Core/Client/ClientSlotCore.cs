using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Client
{
    public class ClientSlotCore : ClientSlot
    {
        public static readonly ClientSlot Player = new ClientSlotCore(1, "Player"); // 0x0
        public static readonly ClientSlot Guild = new ClientSlotCore(2, "Guild"); // 0x8

        public ClientSlotCore(int id, string name) : base(id, name)
        {
        }
    }
}
