namespace Metaplay.Core.Localization
{
    //public class LocalizationLanguageProvider
    //{
    //    public static readonly LocalizationStorageFormat StorageFormat = LocalizationStorageFormat.Binary; // 0x0

    //    private string _basePath; // 0x18
    //    private ConcurrentCache<(LanguageId, ContentHash), LocalizationLanguage> _cache; // 0x20

    //    // 0x10
    //    public IBlobProvider BlobProvider { get; }

    //    public LocalizationLanguageProvider(IBlobProvider blobProvider, string basePath)
    //    {
    //        BlobProvider = blobProvider;

    //        _basePath = basePath;
    //        _cache = new ConcurrentCache<(LanguageId, ContentHash), LocalizationLanguage>();
    //    }

    //    public Task<LocalizationLanguage> GetAsync(LanguageId languageId, ContentHash version)
    //    {
    //        return _cache.GetAsync((languageId, version), async value => LocalizationLanguage.FromBytes(value.Item1, await BlobProvider.GetAsync(GetConfigName(value.Item1), value.Item2), StorageFormat));
    //    }

    //    private string GetConfigName(LanguageId languageId)
    //    {
    //        var fileName = $"{languageId}.{GetConfigNameExtension()}";
    //        return Path.Combine(_basePath, fileName);
    //    }

    //    private static string GetConfigNameExtension()
    //    {
    //        switch (StorageFormat)
    //        {
    //            case LocalizationStorageFormat.LegacyCsv:
    //                return "csv";

    //            case LocalizationStorageFormat.Binary:
    //                return "mpc";

    //            default:
    //                throw new InvalidOperationException($"Invalid LocalizationStorageFormat: {StorageFormat}");
    //        }
    //    }
    //}
}
