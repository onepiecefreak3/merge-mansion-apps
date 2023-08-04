using Metaplay.Core.Model;

namespace Metaplay.Core.Activables
{
    [MetaReservedMembers(200, 300)]
    public abstract class ExtendableEventSet<TId, TInfo, TEventState> : MetaActivableSet<TId, TInfo, TEventState>
    {
        protected ExtendableEventSet()
        {
        }
    }
}