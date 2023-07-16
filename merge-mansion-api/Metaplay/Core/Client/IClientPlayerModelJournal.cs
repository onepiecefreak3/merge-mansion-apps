using Metaplay.Metaplay.Core.Player;

namespace Metaplay.Metaplay.Core.Client
{
    public interface IClientPlayerModelJournal
    {
        // RVA: -1 Offset: -1 Slot: 0
        IPlayerModelBase StagedModel { get; }
    }
}
