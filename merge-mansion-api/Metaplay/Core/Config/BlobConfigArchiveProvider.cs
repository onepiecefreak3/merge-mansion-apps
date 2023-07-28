using System.Threading.Tasks;

namespace Metaplay.Core.Config
{
    public class BlobConfigArchiveProvider : IConfigArchiveProvider
    {
        // Fields
        private readonly IBlobProvider _blobProvider; // 0x10
        private readonly string _configName; // 0x18

        public BlobConfigArchiveProvider(IBlobProvider blobProvider, string configName)
        {
            _blobProvider = blobProvider;
            _configName = configName;
        }

        public async Task<ConfigArchive> GetAsync(ContentHash version)
        {
            var data = await _blobProvider.GetAsync(_configName, version);
            if (data == null)
                return null;

            return ConfigArchive.FromBytes(data);
        }

        public Task<bool> PutAsync(ConfigArchive archive)
        {
            var configBytes = archive.ToBytes();
            return _blobProvider.PutAsync(_configName, archive.Version, configBytes);
        }
    }
}
