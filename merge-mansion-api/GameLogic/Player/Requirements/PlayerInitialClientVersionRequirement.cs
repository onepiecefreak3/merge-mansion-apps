using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(14)]
    public class PlayerInitialClientVersionRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public string Min; // 0x10
        [MetaMember(2, 0)]
        public string Max; // 0x18
    }
}
