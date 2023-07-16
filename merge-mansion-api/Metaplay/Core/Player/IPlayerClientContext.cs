using Metaplay.Metaplay.Core.Client;

namespace Metaplay.Metaplay.Core.Player
{
    public interface IPlayerClientContext
    {
        // STUB

        // RVA: -1 Offset: -1 Slot: 0
        IClientPlayerModelJournal Journal { get; }

        // RVA: -1 Offset: -1 Slot: 2
        MetaTime LastUpdateTimeDebug { get; }

        // RVA: -1 Offset: -1 Slot: 3
        //MetaActionResult ExecuteAction(PlayerActionBase action);
    }
}
