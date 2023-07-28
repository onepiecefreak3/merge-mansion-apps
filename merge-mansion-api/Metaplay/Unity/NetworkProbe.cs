using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Metaplay.Core.Message;
using Metaplay.Core.Network;

namespace Metaplay.Unity
{
    public class NetworkProbe : IDisposable
    {
        private Task _task; // 0x10
        private CancellationTokenSource _cts; // 0x18
        private int _result; // 0x20

        public static NetworkProbe TestConnectivity( /*IMetaLogger log,*/ ServerEndpoint ep)
        {
            if (ep.IsOfflineMode)
                return new NetworkProbe { _result = 1 };

            var primaryUrl = MetaplayCdnAddress.Create(ep.CdnBaseUrl, true).PrimaryBaseUrl;
            primaryUrl += "Connectivity/connectivity-test";

            var probe = new NetworkProbe { _cts = new CancellationTokenSource() };
            probe._task = probe.RunNetworkProbeAsync(primaryUrl, probe._cts.Token);

            return probe;
        }

        public bool? TryGetConnectivityState()
        {
            if (_result == -1)
                return false;

            if (_result == 1)
                return true;

            return null;
        }

        public void Dispose()
        {
            _cts?.Cancel();

            _task = null;
            _cts = null;
        }

        private async Task RunNetworkProbeAsync( /*IMetaLogger log,*/ string probeUrl, CancellationToken ct)
        {
            HttpWebRequest networkProbe = null;

            var abortProbe = new Action(() => networkProbe?.Abort());
            ct.Register(abortProbe);

            var attemptNdx = 0;

        Retry:
            var sw = Stopwatch.StartNew();

            networkProbe = WebRequest.CreateHttp(probeUrl);
            networkProbe.Method = "GET";

            // Log debug "Sending network probe {attemptNdx}"

            var response = await networkProbe.GetResponseAsync();
            var buffer = new byte[2];

            var stream = response.GetResponseStream();
            var read = await stream.ReadAsync(buffer, 0, buffer.Length, ct);

            if (read == 1 && buffer[0] == 'y')
            {
                _result = 1;
                // Log debug "Network probe {attemptNdx + 1} completed successfully (took {sw.ElapsedMilliseconds}ms)."

                return;
            }

            // Log warning "Unexpected contents from probe {attemptNdx + 1}."

            if (attemptNdx == 1)
                _result = -1;

            var wait = attemptNdx != 0 ? 1000 : 500;
            await Task.Delay(wait, ct);

            attemptNdx++;

            if (attemptNdx > 4)
                // Log warning "All network probes failed. Network is not reachable."
                return;

            goto Retry;
        }
    }
}
