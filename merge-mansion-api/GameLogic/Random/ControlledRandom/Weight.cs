using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Random.ControlledRandom
{
    [MetaSerializable]
    public struct Weight
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F32 NextEventTime { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 AverageTimeBetweenEvents { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int OriginalIndex { get; set; }

        public Weight(F32 frequency, int originalIndex)
        {
            NextEventTime = frequency;
            AverageTimeBetweenEvents = frequency;
            OriginalIndex = originalIndex;
        }

        public Weight SetNextEventTime(F32 value)
        {
            // STUB
            return default;
        }

        public class CompareByNextTime
        {
            private readonly F32 referencePoint; // 0x10
            public CompareByNextTime(F32 referencePoint)
            {
                this.referencePoint = referencePoint;
            }

            public bool CompareBool(Weight l, Weight r)
            {
                // STUB
                return false;
            }
        }
    }
}