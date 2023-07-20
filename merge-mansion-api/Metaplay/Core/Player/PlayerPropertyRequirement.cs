using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerPropertyRequirement
    {
        [MetaMember(1)]
        public PlayerPropertyId Id { get; set; }
        [MetaMember(2)]
        public PlayerPropertyConstant Min { get; set; }
        [MetaMember(3)]
        public PlayerPropertyConstant Max { get; set; }
	}
}
