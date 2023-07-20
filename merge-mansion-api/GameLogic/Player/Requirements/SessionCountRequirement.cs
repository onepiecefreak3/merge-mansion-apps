using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(15)]
    [MetaSerializable]
    public class SessionCountRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public Nullable<int> Min; // 0x10
        [MetaMember(2, 0)]
        public Nullable<int> Max; // 0x18
        [MetaMember(3, 0)]
        public Nullable<int> HoursSince; // 0x20
    }
}
