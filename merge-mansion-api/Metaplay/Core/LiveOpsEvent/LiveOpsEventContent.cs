using Metaplay.Core.Model;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class LiveOpsEventContent : IMetaIntegration<LiveOpsEventContent>, IMetaIntegration
    {
        protected LiveOpsEventContent()
        {
        }
    }
}