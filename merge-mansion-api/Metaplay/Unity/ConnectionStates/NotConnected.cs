namespace Metaplay.Metaplay.Unity.ConnectionStates
{
	public class NotConnected : ConnectionState
    {
        public sealed override ConnectionStatus Status => ConnectionStatus.NotConnected;
    }
}
