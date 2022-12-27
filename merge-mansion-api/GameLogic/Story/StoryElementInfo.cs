using System.Collections.Generic;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Story
{
    public class StoryElementInfo : IGameConfigData<StoryDefinitionId>
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
    }
}
