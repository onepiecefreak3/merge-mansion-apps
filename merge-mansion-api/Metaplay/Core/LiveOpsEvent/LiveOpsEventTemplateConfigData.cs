using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Runtime.Serialization;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public class LiveOpsEventTemplateConfigData<TContentClass> : IGameConfigData<LiveOpsEventTemplateId>, IGameConfigData, IHasGameConfigKey<LiveOpsEventTemplateId>, ILiveOpsEventTemplate<TContentClass>, ILiveOpsEventTemplate
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public LiveOpsEventTemplateId TemplateId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public TContentClass Content { get; set; }

        public LiveOpsEventTemplateId ConfigKey => TemplateId;

        public LiveOpsEventContent ContentBase { get; }
        public string DefaultDisplayName { get; }
        public string DefaultDescription { get; }

        public LiveOpsEventTemplateConfigData()
        {
        }
    }
}