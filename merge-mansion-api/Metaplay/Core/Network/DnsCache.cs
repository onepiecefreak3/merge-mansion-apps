using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Network
{
    public static class DnsCache
    {
        private static ConcurrentDictionary<string, DnsCacheEntry> _cache = new ConcurrentDictionary<string, DnsCacheEntry>(); // 0x0

        public static async Task<IPAddress[]> GetHostAddressesAsync(string hostname, AddressFamily af, TimeSpan maxTimeToLive /*, LogChannel log*/)
        {
            var now = DateTime.UtcNow;

            var entryFound = _cache.TryGetValue(hostname, out var entry);
            if (!entryFound || entry.QueriedAt + maxTimeToLive < now)
            {
                var refreshedEntry = await RefreshEntryAsync(hostname);
                if (refreshedEntry == null)
                {
                    if (!entryFound)
                        return Array.Empty<IPAddress>();

                    ; // Log warning "DNS cache refresh failed. Using expired record as a last resort. Host: {hostname}"
                }
                else
                    entry = refreshedEntry;
            }

            int counter;
            IPAddress[] addresses;

            if (af == AddressFamily.InterNetworkV6)
            {
                counter = Interlocked.Increment(ref entry.AddressesIPv6Counter);
                addresses = entry.AddressesIPv6;
            }
            else
            {
                if (af != AddressFamily.InterNetwork)
                    return Array.Empty<IPAddress>();

                counter = Interlocked.Increment(ref entry.AddressesIPv4Counter);
                addresses = entry.AddressesIPv4;
            }

            var res = new IPAddress[addresses.Length];
            for (var i = 0; i < res.Length; i++)
            {
                var cOffset = counter + i;
                var batches = addresses.Length != 0 ? cOffset / addresses.Length : 0;

                res[i] = addresses[cOffset - batches * addresses.Length];
            }

            return res;
        }

        private static async Task<DnsCacheEntry> RefreshEntryAsync(string hostname)
        {
            var entry = await TryResolveHostname(hostname);
            if (entry != null)
                _cache[hostname] = entry;

            return entry;
        }

        private static async Task<DnsCacheEntry> TryResolveHostname(string hostname)
        { 
            var dnsEntry = await Dns.GetHostEntryAsync(hostname);
            return new DnsCacheEntry
            {
                QueriedAt = DateTime.UtcNow,
                AddressesIPv4 = dnsEntry.AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).ToArray(),
                AddressesIPv4Counter = 0,
                AddressesIPv6 = dnsEntry.AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetworkV6).ToArray(),
                AddressesIPv6Counter = 0
            };
        }

        private class DnsCacheEntry
        {
            public DateTime QueriedAt; // 0x10
            public IPAddress[] AddressesIPv4; // 0x18
            public int AddressesIPv4Counter; // 0x20
            public IPAddress[] AddressesIPv6; // 0x28
            public int AddressesIPv6Counter; // 0x30
        }
    }
}
