using Metaplay.Core;
using Metaplay.Core.Math;
using Metaplay.Core.Model;

namespace GameLogic.Player.Board
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
