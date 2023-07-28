using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Metaplay.Core.Network
{
    public static class NetworkDiagnostics
    {
        public static (NetworkDiagnosticReport, Task) GenerateReport(string gameServerHost4,
            string gameServerHost6, List<int> gameServerPorts, bool gameServerUseTls, string cdnHostname4,
            string cdnHostname6, TimeSpan? timeout)
        {
            var localTimeout = timeout ?? TimeSpan.FromSeconds(5);
            var cts = new CancellationTokenSource();
            var report = new NetworkDiagnosticReport(gameServerHost4, gameServerHost6, gameServerPorts, cdnHostname4, cdnHostname6);

            // TODO: Z164

            return (report, Task.FromResult(true));
        }
    }
}
