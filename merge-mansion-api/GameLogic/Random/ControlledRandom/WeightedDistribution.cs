using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Math;

namespace Metaplay.GameLogic.Random.ControlledRandom
{
    class WeightedDistribution
    {
        private static readonly F32 minWeight = F32.Ratio(1, 1000); // 0x0
        private static readonly F32 maxWeight = F32.FromFloat(.25f); // 0x4

        // Fields
        private Weight[] weights; // 0x10

        public WeightedDistribution(List<F32> initializerList)
        {
            weights = initializerList.ZipWithIndex().Select(x =>
            {
                if (x.Item1 < minWeight)
                    throw new ArgumentException($"Invalid weight {x.Item1}, must be between {minWeight} and {maxWeight}");

                if (x.Item1 > maxWeight)
                    throw new ArgumentException($"Invalid weight {x.Item1}, must be between {minWeight} and {maxWeight}");

                return new Weight(F32.Rcp(x.Item1), x.Item2);
            }).ToArray();
        }

        public WeightedDistribution(Weight[] existingWeights)
        {
            weights = existingWeights;
        }

        public Weight[] GetWeights() => weights;

        public void Initialize(RandomPCG rng)
        {
            if (rng == null)
                return;

            for (var i = 0; i < weights.Length; i++)
            {
                var weight = weights[i];

                var rngInt = rng.NextInt(weight.AverageTimeBetweenEvents.Raw + 1);

                weight.NextEventTime = new F32(rngInt);
                weights[i] = weight;
            }

            var compare = new Weight.CompareByNextTime(F32.FromInt(0));

            // TODO: Update weights
            //var heap = new MaxHeap<Weight>(weights, compare);
            //weights = heap.GetAsArray();
        }

        public int PickRandom(RandomPCG rng)
        {
            var weight = weights[0];

            var nextTime = weight.NextEventTime;

            var rngInt = rng.NextInt(weight.AverageTimeBetweenEvents.Raw + 1);
            var newNextTime = weight.NextEventTime + rngInt;

            weight.NextEventTime = newNextTime;
            weights[0] = weight;

            var compare = new Weight.CompareByNextTime(nextTime);
            HeapTopUpdated(weights, compare);

            return weight.OriginalIndex;
        }

        private static void HeapTopUpdated(IList<Weight> weights, Weight.CompareByNextTime compare)
        {
            var start = 0;
            for (var i = 1; i < weights.Count;)
            {
                var switchIndex = i;
                if (i + 1 < weights.Count)
                {
                    var weight = weights[i];
                    var nextWeight = weights[i + 1];

                    var compared = compare.CompareBool(weight, nextWeight);
                    if (compared)
                        switchIndex = i + 1;
                }

                var previousWeight = weights[start];
                var switchWeight = weights[switchIndex];
                if(!compare.CompareBool(previousWeight, switchWeight))
                    return;

                weights[start] = switchWeight;
                weights[switchIndex] = previousWeight;

                i = switchIndex << 1 | 1;
                start = switchIndex;
            }
        }
    }
}
