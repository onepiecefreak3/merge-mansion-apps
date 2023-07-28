using GameLogic.Story.SlideShows;
using Metaplay.Core.Model;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(6)]
    [MetaSerializable]
    public class TriggerSlideShow : IDirectorAction
    {
        [MetaMember(1, 0)]
        private SlideShowId SlideShowId { get; set; }
    }
}
