using Metaplay.Core.Model;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class LiveOpsEventContent : IMetaIntegration<LiveOpsEventContent>, IMetaIntegration
    {
        protected LiveOpsEventContent()
        {
        }
    }
}