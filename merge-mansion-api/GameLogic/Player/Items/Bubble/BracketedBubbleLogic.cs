using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Bubble
{
    [MetaSerializableDerived(2)]
    public class BracketedBubbleLogic : IBubbleLogic
    {
        [MetaMember(1, 0)]
        private List<Bracket> Brackets { get; set; }
        [MetaMember(2, 0)]
        private F32 NonNeededPenalty { get; set; }
        [MetaMember(3, 0)]
        private F32 HardestTaskBoost { get; set; }
        [MetaMember(4, 0)]
        private F32 NormalizationQuot { get; set; }
        [MetaMember(5, 0)]
        private int MaxBubblesOnBoard { get; set; }

        public class Bracket
        {
            [MetaMember(1, 0)]
            public MetaDuration? Min { get; set; }
            [MetaMember(2, 0)]
            public MetaDuration? Max { get; set; }
            [MetaMember(3, 0)]
            public F32 Quotient { get; set; }
        }
	}
}
