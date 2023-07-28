using System;
using System.Threading.Tasks;

namespace Metaplay.Core
{
    public interface IBlobStorage : IDisposable
    {
        // RVA: -1 Offset: -1 Slot: 0
        Task<byte[]> GetAsync(string fileName);

        Task<bool> PutAsync(string fileName, byte[] bytes, BlobStoragePutHints hintsMaybe);

        Task DeleteAsync(string fileName);
    }
}
