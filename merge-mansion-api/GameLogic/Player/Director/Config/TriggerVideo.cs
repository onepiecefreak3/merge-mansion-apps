using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Story.Videos;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(5)]
    [MetaSerializable]
    public class TriggerVideo : IDirectorAction
    {
        [MetaMember(1, 0)]
        private VideoId VideoId { get; set; }
    }
}
