namespace Metaplay.Metaplay.Unity.ConnectionStates
{
	public class Connecting : ConnectionState
    {
        public readonly int ConnectionAttempt; // 0x10

        public sealed override ConnectionStatus Status => ConnectionStatus.Connecting;

        public Connecting(int connectionAttempt)
        {
            ConnectionAttempt = connectionAttempt;
        }
    }
}
