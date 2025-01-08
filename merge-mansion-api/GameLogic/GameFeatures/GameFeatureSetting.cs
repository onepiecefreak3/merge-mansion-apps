using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using GameLogic.Player.ScheduledActions;
using Metaplay.Core;
using Metaplay.Core.Player;

namespace GameLogic.GameFeatures
{
    [MetaBlockedMembers(new int[] { 3, 4 })]
    [MetaSerializable]
    public class GameFeatureSetting : IGameConfigData<GameFeatureId>, IGameConfigData, IHasGameConfigKey<GameFeatureId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GameFeatureId GameFeatureId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsEnabled { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<PlayerRequirement> PreviewRequirements { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<PlayerRequirement> UnlockRequirements { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool ShouldBePersisted { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public IScheduledAction PersistedAction { get; set; }
        public GameFeatureId ConfigKey => GameFeatureId;

        public GameFeatureSetting()
        {
        }

        public GameFeatureSetting(GameFeatureId id, bool isEnabled, List<PlayerRequirement> previewRequirements, List<PlayerRequirement> unlockRequirements, bool shouldBePersisted, IScheduledAction persistedAction)
        {
        }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<MetaRef<PlayerSegmentInfoBase>> Segments { get; set; }

        public GameFeatureSetting(GameFeatureId id, bool isEnabled, List<PlayerRequirement> previewRequirements, List<PlayerRequirement> unlockRequirements, bool shouldBePersisted, IScheduledAction persistedAction, List<MetaRef<PlayerSegmentInfoBase>> segments)
        {
        }
    }
}