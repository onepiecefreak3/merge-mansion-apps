using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(11)]
    public class PlayerCurrentTimeRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public Nullable<MetaTime> StartInclusive { get; set; }
        [MetaMember(2, 0)]
        public Nullable<MetaTime> EndExclusive { get; set; }
        [MetaMember(3, 0)]
        public string LocalizationKey { get; set; }
    }
}
