using System;

namespace Metaplay.Metaplay.Core.Network
{
    public struct MetaplayCdnAddress
    {
        // Fields
        private readonly bool _prioritizeIPv4; // 0x0
        public readonly string IPv4BaseUrl; // 0x8
        public readonly string IPv6BaseUrl; // 0x10

        public static MetaplayCdnAddress Empty => new MetaplayCdnAddress(false, null, null);

        // Properties
        public string PrimaryBaseUrl => _prioritizeIPv4 ? IPv4BaseUrl : IPv6BaseUrl;
        public string SecondaryBaseUrl => _prioritizeIPv4 ? IPv6BaseUrl : IPv4BaseUrl;
        public bool IsEmpty => IPv4BaseUrl == null;

        private MetaplayCdnAddress(bool prioritizeIPv4, string iPv4BaseUrl, string iPv6BaseUrl)
        {
            _prioritizeIPv4 = prioritizeIPv4;
            IPv4BaseUrl = iPv4BaseUrl;
            IPv6BaseUrl = iPv6BaseUrl;
        }

        public static MetaplayCdnAddress Create(string cdnBaseUrl, bool prioritizeIPv4)
        {
            if (cdnBaseUrl == null)
                throw new ArgumentNullException(nameof(cdnBaseUrl));

            if (!cdnBaseUrl.EndsWith('/'))
                cdnBaseUrl = string.Concat(cdnBaseUrl, '/');

            var ipv4 = GetV4V6SpecificCdn(cdnBaseUrl, true);
            var ipv6 = GetV4V6SpecificCdn(cdnBaseUrl, false);

            return new MetaplayCdnAddress(prioritizeIPv4, ipv4, ipv6);
        }

        private static string GetV4V6SpecificCdn(string baseUrl, bool isIPv4)
        {
            var uri = new Uri(baseUrl);
            var builder = new UriBuilder(uri);

            var host = MetaplayHostnameUtil.GetV4V6SpecificHost(builder.Host, isIPv4);
            builder.Host = host;

            return builder.Uri.AbsoluteUri;
        }

        public MetaplayCdnAddress GetSubdirectoryAddress(string directoryName)
        {
            if (IPv4BaseUrl == null)
                throw new InvalidOperationException();

            var fullIpv4 = string.Concat(IPv4BaseUrl, directoryName, '/');
            var fullIpv6 = string.Concat(IPv6BaseUrl, directoryName, '/');

            return new MetaplayCdnAddress(_prioritizeIPv4, fullIpv4, fullIpv6);
        }

        public MetaplayCdnAddress TryGetSubdirectoryAddress(string directoryName)
        {
            if (IPv4BaseUrl == null)
                return Empty;

            return GetSubdirectoryAddress(directoryName);
        }
    }
}
