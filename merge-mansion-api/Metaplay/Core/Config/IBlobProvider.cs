using System;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Config
{
    public interface IBlobProvider : IDisposable
    {
        // RVA: -1 Offset: -1 Slot: 0
        Task<byte[]> GetAsync(string configName, ContentHash version);

        // RVA: -1 Offset: -1 Slot: 1
        Task<bool> PutAsync(string configName, ContentHash version, byte[] value);
    }
}
