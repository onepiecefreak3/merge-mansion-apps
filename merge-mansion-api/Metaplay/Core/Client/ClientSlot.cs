using System;

namespace Metaplay.Core.Client
{
    public class ClientSlot : DynamicEnum<ClientSlot>
    {
        protected ClientSlot(int id, string name) : base(id, name, true)
        {
        }
    }
}