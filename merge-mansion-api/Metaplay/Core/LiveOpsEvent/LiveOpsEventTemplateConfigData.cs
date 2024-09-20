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

        public string DefaultDisplayName => throw new System.NotImplementedException();

        public string DefaultDescription => throw new System.NotImplementedException();

        public LiveOpsEventContent ContentBase => throw new System.NotImplementedException();

        public LiveOpsEventTemplateConfigData()
        {
        }
    }
}