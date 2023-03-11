using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.GameLogic.Config
{
    public abstract class PlayerPropertyMatcher : PlayerPropertyId
    {
    }

    public abstract class PlayerPropertyMatcher<TValue> : PlayerPropertyMatcher
    {
        [MetaMember(100, 0)]
        protected TValue _value { get; set; }
    }
}
