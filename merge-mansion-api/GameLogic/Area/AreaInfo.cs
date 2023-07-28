using System.Collections.Generic;
using GameLogic.Hotspots;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace GameLogic.Area
{
    [MetaSerializable]
    public class AreaInfo : IGameConfigData<AreaId>
    {
        [MetaMember(1, 0)]
        public AreaId AreaId { get; set; }
        [MetaMember(2, 0)]
        public string TitleLocalizationId { get; set; }
        [MetaMember(3, 0)]
        public string CategoryLocalizationId { get; set; }
        [MetaMember(4, 0)]
        public List<PlayerRequirement> TeaseRequirements { get; set; }
        [MetaMember(5, 0)]
        public List<PlayerRequirement> UnlockRequirements { get; set; }
        [MetaMember(7, 0)]
        public List<PlayerReward> Rewards { get; set; }
        [MetaMember(8, 0)]
        public List<MetaRef<HotspotDefinition>> HotspotsRefs { get; set; }
        [MetaMember(9, 0)]
        public MetaRef<HotspotDefinition> UnlockingHotspotRef { get; set; }
        [MetaMember(10, 0)]
        public string LockedDescriptionLocalizationId { get; set; }
        [MetaMember(11, 0)]
        public string UnlockedDescriptionLocalizationId { get; set; }
        [MetaMember(12, 0)]
        public string ShortDescriptionLocalizationId { get; set; }

        public AreaId ConfigKey => AreaId;
    }
}
