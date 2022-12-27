using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Story.SlideShows;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(6)]
    public class TriggerSlideShow : IDirectorAction
    {
        [MetaMember(1, 0)]
        private SlideShowId SlideShowId { get; set; }
    }
}
