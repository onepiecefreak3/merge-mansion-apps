using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using GameLogic.Utility.Debugging;
using GameLogic.MergeChains;
using System;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class BracketedBubbleLogic : IBubbleLogic, IProvidesDebugOutput
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

        [MetaSerializable]
        public class Bracket
        {
            [MetaMember(1, 0)]
            public MetaDuration? Min { get; set; }

            [MetaMember(2, 0)]
            public MetaDuration? Max { get; set; }

            [MetaMember(3, 0)]
            public F32 Quotient { get; set; }

            private Bracket()
            {
            }

            public Bracket(MetaDuration? min, MetaDuration? max, F32 quotient)
            {
            }
        }

        [MetaMember(6, (MetaMemberFlags)0)]
        private List<MetaRef<MergeChainDefinition>> ChainsWithSimplifiedLogic { get; set; }

        private BracketedBubbleLogic()
        {
        }

        public BracketedBubbleLogic(IEnumerable<ValueTuple<F32, MetaDuration?, MetaDuration?>> brackets, F32 nonNeededPenalty, F32 hardestTaskBoost, F32 normalizationQuot, int maxBubblesOnBoard, IEnumerable<MergeChainId> chainsWithSimplifiedLogic)
        {
        }
    }
}