using GameLogic.Story.SlideShows;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(6)]
    public class TriggerSlideShow : IDirectorAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private SlideShowId SlideShowId { get; set; }

        private TriggerSlideShow()
        {
        }

        public TriggerSlideShow(SlideShowId slideShowId)
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}