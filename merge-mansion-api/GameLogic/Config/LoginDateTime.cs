using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.GameLogic.Config
{
    public struct LoginDateTime
    {
        [MetaMember(1, 0)]
        public MetaTime Time { get; set; }
    }
}
