using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Board
{
    [MetaSerializable]
    public class BoardBubbleState
    {
        [MetaMember(1, 0)]
        public MetaTime LastBubbleAppearance { get; set; }
        [MetaMember(2, 0)]
        public MetaTime GraceChanceTimestamp { get; set; }
        [MetaMember(3, 0)]
        public F32 GraceChance { get; set; }
        [MetaMember(4, 0)]
        public MetaTime BehaviourChanceTimestamp { get; set; }
        [MetaMember(5, 0)]
        public F32 BehaviourChance { get; set; }
	}
}
