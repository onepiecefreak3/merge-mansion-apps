namespace Metaplay.Core.Json
{
    public enum JsonSerializationMode
    {
        Default = 0,
        GdprExport = 1,
        AnalyticsEvents = 2,
        AdminApi = 3
    }
}