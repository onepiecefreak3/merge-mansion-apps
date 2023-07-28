using Metaplay.Core.Client;
using Metaplay.Core.Player;

namespace Metaplay.Unity
{
	public interface ISessionContextProvider
    {
        // RVA: -1 Offset: -1 Slot: 0
        IPlayerClientContext PlayerContext { get; }
        // RVA: -1 Offset: -1 Slot: 1
        MetaplayClientStore ClientStore { get; }
    }
}
