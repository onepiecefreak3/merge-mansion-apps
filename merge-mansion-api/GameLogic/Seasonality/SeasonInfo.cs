using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using GameLogic.ConfigPrefabs;
using GameLogic.Player.Director.Config;

namespace GameLogic.Seasonality
{
    [MetaSerializable]
    public class SeasonInfo : IGameConfigData<SeasonId>, IGameConfigData, IGameConfigKey<SeasonId>
    {
        public SeasonId ConfigKey => Id;

        [MetaMember(1, (MetaMemberFlags)0)]
        public SeasonId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Type { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerRequirement> UnlockRequirements { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public ConfigPrefabId StartPopupId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<IDirectorAction> StartActions { get; set; }

        public SeasonInfo()
        {
        }

        public SeasonInfo(SeasonId seasonId, string type, IEnumerable<PlayerRequirement> unlockRequirements, ConfigPrefabId startPopupId, List<IDirectorAction> startActions)
        {
        }
    }
}