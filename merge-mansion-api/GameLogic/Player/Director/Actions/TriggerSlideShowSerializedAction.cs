using Metaplay.Core.Model;
using GameLogic.Story.SlideShows;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(4)]
    public class TriggerSlideShowSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private SlideShowId SlideShowId { get; set; }

        private TriggerSlideShowSerializedAction()
        {
        }

        public TriggerSlideShowSerializedAction(SlideShowId slideShowId)
        {
        }
    }
}