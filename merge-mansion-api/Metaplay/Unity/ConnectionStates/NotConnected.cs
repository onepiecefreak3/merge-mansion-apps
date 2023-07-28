namespace Metaplay.Unity.ConnectionStates
{
	public class NotConnected : ConnectionState
    {
        public sealed override ConnectionStatus Status => ConnectionStatus.NotConnected;
    }
}
