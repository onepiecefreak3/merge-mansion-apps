using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(8)]
    [MetaSerializable]
    public class MarkDirectorGroupComplete : IDirectorAction
    {
        [MetaMember(1, 0)]
        private DCGroupId DirectorGroupId { get; set; }
    }
}
