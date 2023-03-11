using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1029)]
    public class PlayerPropertyLastKnownPlatform : PlayerPropertyMatcher<ClientPlatform>
    {
    }
}
