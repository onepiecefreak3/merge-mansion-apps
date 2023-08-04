using Metaplay.Core.Model;
using GameLogic.Story.Videos;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(3)]
    public class TriggerVideoSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private VideoId VideoId { get; set; }

        private TriggerVideoSerializedAction()
        {
        }

        public TriggerVideoSerializedAction(VideoId videoId)
        {
        }
    }
}