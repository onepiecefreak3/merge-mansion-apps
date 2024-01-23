using GameLogic.Story.Videos;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(5)]
    public class TriggerVideo : IDirectorAction
    {
        [MetaMember(1, 0)]
        private VideoId VideoId { get; set; }

        private TriggerVideo()
        {
        }

        public TriggerVideo(VideoId videoId)
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}