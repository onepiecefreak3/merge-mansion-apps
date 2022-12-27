using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Merge;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(3)]
    public class DelayFinalizationToBoard : IDirectorAction
    {
        [MetaMember(1, 0)]
        private MergeBoardId BoardId { get; set; }
    }
}
