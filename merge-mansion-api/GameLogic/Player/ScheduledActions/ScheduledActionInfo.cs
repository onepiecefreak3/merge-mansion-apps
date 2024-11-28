using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Player.ScheduledActions
{
    [MetaActivableConfigData("ScheduledAction", false, true)]
    [MetaSerializable]
    public class ScheduledActionInfo : IMetaActivableConfigData<ScheduledActionId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<ScheduledActionId>, IHasGameConfigKey<ScheduledActionId>, IMetaActivableInfo<ScheduledActionId>
    {
        public ScheduledActionId ActivableId => ConfigKey;

        [MetaMember(1, (MetaMemberFlags)0)]
        public ScheduledActionId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public IScheduledAction ScheduledAction { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }
        public string DisplayShortInfo { get; }

        public ScheduledActionInfo(ScheduledActionId configKey, string displayName, string description, MetaActivableParams activableParams, IScheduledAction scheduledAction)
        {
        }

        public ScheduledActionInfo()
        {
        }
    }
}