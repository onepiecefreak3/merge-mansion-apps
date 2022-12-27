using System;

namespace Metaplay.Metaplay.Core.Network
{
    public static class MetaplayHostnameUtil
    {
        public static string GetV4V6SpecificHost(string hostname, bool isIPv4)
        {
            if (hostname == "localhost" || hostname == "127.0.0.1" || hostname == "[::1]")
                return isIPv4 ? "127.0.0.1" : "[::1]";

            var splitHost = hostname?.Split('.');
            if (splitHost == null)
                throw new ArgumentException(nameof(hostname));

            if (splitHost.Length != 0)
                splitHost[0] = EnsureOrRemoveSuffix(splitHost[0], "-ipv6", !isIPv4);

            return string.Join('.', splitHost);
        }

        private static string EnsureOrRemoveSuffix(string input, string suffix, bool shouldHaveSuffix)
        {
            if (input.EndsWith(suffix, StringComparison.Ordinal))
                input = input.Substring(0, input.Length - suffix.Length);

            if (shouldHaveSuffix)
                input = string.Concat(input, suffix);

            return input;
        }
    }
}
