using System;
using System.Threading.Tasks;

namespace Metaplay.Core.Config
{
    public class CachingBlobProvider : IBlobProvider
    {
        // Fields
        private readonly IBlobProvider _provider; // 0x10
        private readonly IBlobProvider _cache; // 0x18

        public CachingBlobProvider(IBlobProvider provider, IBlobProvider cache)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public void Dispose() { }

        public async Task<byte[]> GetAsync(string configName, ContentHash version)
        {
            var cacheData = await _cache.GetAsync(configName, version);
            if (cacheData != null)
                return cacheData;

            var providerData = await _provider.GetAsync(configName, version);
            if (providerData == null)
                return null;

            await _cache.PutAsync(configName, version, providerData);
            return providerData;
        }

        public Task<bool> PutAsync(string configName, ContentHash version, byte[] value)
        {
            throw new InvalidOperationException("CachingBlobProvider.PutAsync(): operation not supported");
        }
    }
}
