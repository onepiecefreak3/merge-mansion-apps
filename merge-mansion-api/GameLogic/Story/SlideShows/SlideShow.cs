using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using GameLogic.Player.Director.Config;

namespace GameLogic.Story.SlideShows
{
    [MetaSerializable]
    public class SlideShow : IGameConfigData<SlideShowId>, IGameConfigData, IHasGameConfigKey<SlideShowId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SlideShowId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<Slide> SlideShowSlides { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<IDirectorAction> CompleteActions { get; set; }
        public IEnumerable<Slide> Slides { get; }
        public IEnumerable<IDirectorAction> OnComplete { get; }

        public SlideShow()
        {
        }

        public SlideShow(SlideShowId configKey, IEnumerable<Slide> slides, IEnumerable<IDirectorAction> completeActions)
        {
        }
    }
}