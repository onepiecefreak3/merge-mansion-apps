using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Client
{
    [MetaSerializable]
    public class ClientSlot : DynamicEnum<ClientSlot>
    {
        protected ClientSlot(int id, string name) : base(id, name, true)
        {
        }
    }
}