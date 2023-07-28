using System;
using System.Threading.Tasks;

namespace Metaplay.Core.Config
{
    public class StorageBlobProvider : IBlobProvider
    {
        private readonly IBlobStorage _storage; // 0x10

        public StorageBlobProvider(IBlobStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void Dispose() { }

        public string GetStorageFileName(string configName, ContentHash version)
        {
            return $"{configName}/{version}";
        }

        public IBlobStorage GetStorage()
        {
            return _storage;
        }

        public async Task<byte[]> GetAsync(string configName, ContentHash version)
        {
            var fileName = GetStorageFileName(configName, version);
            return await _storage.GetAsync(fileName);
        }

        public async Task<bool> PutAsync(string configName, ContentHash version, byte[] value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var fileName = GetStorageFileName(configName, version);
            return await _storage.PutAsync(fileName, value, null);
        }
    }
}
