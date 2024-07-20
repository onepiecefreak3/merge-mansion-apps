using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Localization;
using System;

namespace GameLogic.Story.SlideShows
{
    public class SlideShowSource : IConfigItemSource<SlideShow, SlideShowId>, IGameConfigSourceItem<SlideShowId, SlideShow>, IHasGameConfigKey<SlideShowId>
    {
        public SlideShowId ConfigKey { get; set; }
        private List<MetaDuration> SlideDuration { get; set; }
        private List<TranslationId> SlideText { get; set; }
        private List<string> SlideAsset { get; set; }
        private List<string> CompleteAction { get; set; }

        public SlideShowSource()
        {
        }
    }
}