using System;

namespace Metaplay.Core.Config
{
    public interface IConfigArchive
    {
        ContentHash Version { get; }
        
        // RVA: -1 Offset: -1 Slot: 1
        ArraySegment<byte> GetEntryBytes(string name);

        // RVA: -1 Offset: -1 Slot: 2
        bool ContainsEntryWithName(string name);
    }
}
