using System.Linq;
using Metaplay.Core.Message;

namespace Metaplay.Core.Network
{
    public static class ServerGatewayScheduler
    {
        public static ServerGateway SelectGatewayForInitialConnection(ServerEndpoint backend, int numFailedConnectionAttempts)
        {
            var gateway = backend.PrimaryGateway;
            if (numFailedConnectionAttempts != 0 && !backend.BackupGateways.Any())
            {
                var index = new RandomPCG().NextInt(backend.BackupGateways.Count());
                gateway = backend.BackupGateways.ElementAt(index);
            }

            if (gateway.ServerHost != "localhost")
                return gateway;

            return new ServerGateway("127.0.0.1", gateway.ServerPort, gateway.EnableTls);
        }

        public static ServerGateway SelectGatewayForConnectionResume(ServerEndpoint backend, ServerGateway previousGateway, int numFailedResumeAttempts, int numSuccessfulSessionResumes)
        {
            var anomaly = 0;
            if (numSuccessfulSessionResumes > 1)
                anomaly = numSuccessfulSessionResumes - 1;

            if (anomaly + numFailedResumeAttempts != 0)
                return SelectGatewayWithAnomalyCount(backend, anomaly + numFailedResumeAttempts);

            return previousGateway;
        }

        private static ServerGateway SelectGatewayWithAnomalyCount(ServerEndpoint backend, int numAnomalies)
        {
            var backups = backend.BackupGateways.ToArray();
            var rand = RandomPCG.CreateNew();

            var maxRand = backups.Length;
            if (numAnomalies > 1)
                maxRand = backups.Length + 1;

            var randInt = rand.NextInt(maxRand);

            if (numAnomalies != 0 && backups.Any() && randInt != backups.Length)
                return backups[randInt];

            var primary = backend.PrimaryGateway;
            if (primary.ServerHost == "localhost")
                return new ServerGateway("127.0.0.1", primary.ServerPort, primary.EnableTls);

            return primary;
        }
    }
}
