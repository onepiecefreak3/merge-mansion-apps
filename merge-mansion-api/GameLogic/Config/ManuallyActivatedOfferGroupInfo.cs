using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class ManuallyActivatedOfferGroupInfo : IGameConfigData<ManuallyActivatedOfferGroupId>, IGameConfigData, IHasGameConfigKey<ManuallyActivatedOfferGroupId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ManuallyActivatedOfferGroupId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int MaxTriggeredPerSession { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerRequirement> ActivationRequirements { get; set; }

        public ManuallyActivatedOfferGroupInfo()
        {
        }

        public ManuallyActivatedOfferGroupInfo(ManuallyActivatedOfferGroupId configKey, int maxTriggeredPerSession, List<PlayerRequirement> activationRequirements)
        {
        }
    }
}