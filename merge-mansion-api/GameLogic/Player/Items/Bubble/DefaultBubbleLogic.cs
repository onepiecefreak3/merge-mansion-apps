using Metaplay.Core.Math;
using Metaplay.Core.Model;
using GameLogic.Utility.Debugging;
using System;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializableDerived(1)]
    public class DefaultBubbleLogic : IBubbleLogic, IProvidesDebugOutput
    {
        [MetaMember(1, 0)]
        private int MaxBubblesOnBoard { get; set; }

        [MetaMember(2, 0)]
        private F32 FirstEncounterQuotient { get; set; }

        [MetaMember(3, 0)]
        private int RollScale { get; set; }

        [MetaMember(4, 0)]
        private int BubbleCountAdjustmentQuotient { get; set; }

        [MetaMember(5, 0)]
        private F32 GraceRecoverySpeed { get; set; }

        [MetaMember(6, 0)]
        private F32 GraceChanceReduction { get; set; }

        [MetaMember(7, 0)]
        private F32 MaxGraceChance { get; set; }

        [MetaMember(8, 0)]
        private F32 MinGraceChance { get; set; }

        [MetaMember(9, 0)]
        private F32 BehaviorChanceRecoverySpeed { get; set; }

        [MetaMember(10, 0)]
        private F32 BehaviourChanceReduction { get; set; }

        [MetaMember(11, 0)]
        private F32 MaxBubbleBehaviourChance { get; set; }

        [MetaMember(12, 0)]
        private F32 MinBubbleBehaviourChance { get; set; }

        private DefaultBubbleLogic()
        {
        }

        public DefaultBubbleLogic(int maxBubblesOnBoard, F32 firstEncounterQuotient, int rollScale, int bubbleCountAdjustmentQuotient)
        {
        }

        public DefaultBubbleLogic(int maxBubblesOnBoard, F32 firstEncounterQuotient, int rollScale, int bubbleCountAdjustmentQuotient, F32 graceRecoverySpeed, F32 graceChanceReduction, F32 maxGraceChance, F32 minGraceChance, F32 behaviorChanceRecoverySpeed, F32 behaviourChanceReduction, F32 maxBubbleBehaviourChance, F32 minBubbleBehaviourChance)
        {
        }
    }
}