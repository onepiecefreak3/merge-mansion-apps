using System.Collections.Generic;
using GameLogic.Player.Director.Config;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;
using System;

namespace GameLogic.Story
{
    [MetaSerializable]
    public class StoryElementInfo : IGameConfigData<StoryDefinitionId>, IGameConfigData, IValidatable
    {
        [MetaMember(1, 0)]
        private StoryDefinitionId StoryDefinitionId { get; set; }

        [MetaMember(2, 0)]
        public bool StealAllSteps { get; set; }

        [MetaMember(3, 0)]
        public Dictionary<DialogItemId, MetaRef<DialogItemInfo>> DialogItems { get; set; }

        [MetaMember(4, 0)]
        public string Music { get; set; }

        [MetaMember(5, 0)]
        public int MusicTriggerIndex { get; set; }

        [MetaMember(6, 0)]
        private List<IDirectorAction> CompleteActions { get; set; }

        [MetaMember(7, 0)]
        public bool SupportsSimpleSkip { get; set; }
        public StoryDefinitionId ConfigKey => StoryDefinitionId;
        public IEnumerable<IDirectorAction> OnComplete => CompleteActions;

        [MetaMember(8, (MetaMemberFlags)0)]
        public float StartDelay { get; set; }

        public StoryElementInfo()
        {
        }

        public StoryElementInfo(StoryDefinitionId storyDefinitionId, bool stealAllSteps, Dictionary<DialogItemId, MetaRef<DialogItemInfo>> dialogItems, string music, int musicTriggerIndex, IEnumerable<IDirectorAction> completeActions, bool supportsSimpleSkip, float startDelay)
        {
        }
    }
}