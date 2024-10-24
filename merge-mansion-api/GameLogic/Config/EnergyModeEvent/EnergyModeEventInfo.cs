using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using GameLogic.Player.Modes;
using GameLogic.Player.Requirements;

namespace GameLogic.Config.EnergyModeEvent
{
    [MetaSerializable]
    [MetaActivableConfigData("EnergyModeEvent", false, true)]
    public class EnergyModeEventInfo : IMetaActivableConfigData<EnergyModeEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<EnergyModeEventId>, IHasGameConfigKey<EnergyModeEventId>, IMetaActivableInfo<EnergyModeEventId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EnergyModeEventId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaRef<EnergyModeInfo> EnergyModeRef { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }
        public EnergyModeEventId ActivableId { get; }
        public string DisplayShortInfo { get; }

        public EnergyModeEventInfo()
        {
        }

        public EnergyModeEventInfo(EnergyModeEventId configKey, string displayName, string description, MetaRef<EnergyModeInfo> energyModeRef, MetaActivableParams activableParams, PlayerRequirement unlockRequirement, string nameLocId)
        {
        }
    }
}