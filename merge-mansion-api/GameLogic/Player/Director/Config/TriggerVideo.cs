using GameLogic.Story.Videos;
using Metaplay.Core.Model;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(5)]
    [MetaSerializable]
    public class TriggerVideo : IDirectorAction
    {
        [MetaMember(1, 0)]
        private VideoId VideoId { get; set; }
    }
}
