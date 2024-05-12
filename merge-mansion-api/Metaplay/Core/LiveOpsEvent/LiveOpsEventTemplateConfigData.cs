using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Runtime.Serialization;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public class LiveOpsEventTemplateConfigData<TContentClass> : IGameConfigData<LiveOpsEventTemplateId>, IGameConfigData, IHasGameConfigKey<LiveOpsEventTemplateId>, ILiveOpsEventTemplate
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public LiveOpsEventTemplateId TemplateId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public TContentClass Content { get; set; }

        [IgnoreDataMember]
        public LiveOpsEventContent ContentBase { get; }
        public LiveOpsEventTemplateId ConfigKey { get; }

        public LiveOpsEventTemplateConfigData()
        {
        }
    }
}