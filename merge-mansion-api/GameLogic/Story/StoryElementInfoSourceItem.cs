using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Story
{
    public class StoryElementInfoSourceItem : IConfigItemSource<StoryElementInfo, StoryDefinitionId>, IGameConfigSourceItem<StoryDefinitionId, StoryElementInfo>, IHasGameConfigKey<StoryDefinitionId>
    {
        private StoryDefinitionId StoryDefinitionId { get; set; }
        private bool StealAllSteps { get; set; }
        private List<MetaRef<DialogItemInfo>> DialogItems { get; set; }
        private List<string> CompleteAction { get; set; }
        private string MusicTrack { get; set; }
        private int MusicTriggerIndex { get; set; }
        private bool SupportsSimpleSkip { get; set; }
        private float StartDelay { get; set; }
        public StoryDefinitionId ConfigKey { get; }

        public StoryElementInfoSourceItem()
        {
        }
    }
}