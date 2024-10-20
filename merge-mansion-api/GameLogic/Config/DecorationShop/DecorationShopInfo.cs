using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Player.Requirements;

namespace GameLogic.Config.DecorationShop
{
    [MetaActivableConfigData("DecorationShop", false, true)]
    [MetaSerializable]
    public class DecorationShopInfo : IMetaActivableConfigData<DecorationShopId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<DecorationShopId>, IHasGameConfigKey<DecorationShopId>, IMetaActivableInfo<DecorationShopId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DecorationShopId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<MetaRef<DecorationShopSetInfo>> SetRefs { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }
        public DecorationShopId ActivableId { get; }
        public string DisplayShortInfo { get; }

        public DecorationShopInfo()
        {
        }

        public DecorationShopInfo(DecorationShopId configKey, string displayName, string description, string nameLocId, List<MetaRef<DecorationShopSetInfo>> setRefs, MetaActivableParams activableParams, PlayerRequirement unlockRequirement)
        {
        }
    }
}