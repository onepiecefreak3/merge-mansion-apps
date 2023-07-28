namespace Metaplay.Unity
{
    public struct ConnectionStatistics // TypeDefIndex: 12971
    {
        public CurrentConnectionStats CurrentConnection; // 0x0

        public static ConnectionStatistics CreateNew()
        {
            return new ConnectionStatistics();
        }

        public struct CurrentConnectionStats
        {
            public bool HasCompletedHandshake; // 0x0
            public bool HasCompletedSessionInit; // 0x1
            public bool? NetworkProbeStatus; // 0x2

            public static CurrentConnectionStats ForNewConnection()
            {
                return new CurrentConnectionStats();
            }
        }
    }
}
