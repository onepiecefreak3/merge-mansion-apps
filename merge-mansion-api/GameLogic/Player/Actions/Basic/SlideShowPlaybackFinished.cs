using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Story.SlideShows;

namespace GameLogic.Player.Actions.Basic
{
    [ModelAction(11056)]
    public class SlideShowPlaybackFinished : PlayerAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<SlideShow> SlideShow { get; set; }

        private SlideShowPlaybackFinished()
        {
        }

        public SlideShowPlaybackFinished(MetaRef<SlideShow> slideShow)
        {
        }
    }
}