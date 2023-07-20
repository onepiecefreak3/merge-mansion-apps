using System;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core
{
    [MetaSerializable]
    public class RandomPCG
    {
        private const ulong Multiplier = 0x5851f42d4c957f2d;
        private const ulong Increment = 0x14057B7EF767814F;
        private const float ToFloat01 = 2.3283064E-10f;
        private const double ToDouble01 = 2.3283064365386963E-10;

        [MetaMember(1, 0)]
        private ulong _state; // 0x10

        public RandomPCG()
        {
            _state = 0;
        }

        private RandomPCG(ulong seed)
        {
            _state = seed * Multiplier + 0x1a08ee1184ba6d32;
        }

        public RandomPCG(RandomPCG other)
        {
            _state = other._state;
        }

        public static RandomPCG CreateNew()
        {
            return new RandomPCG(GetRandomSeed() * Multiplier + 0x1a08ee1184ba6d32);
        }

        private static ulong GetRandomSeed()
        {
            return (ulong)(Guid.NewGuid().GetHashCode() ^ Environment.TickCount) |
                   ((ulong)(Guid.NewGuid().GetHashCode() ^ Environment.TickCount) << 0x20);
        }

        public int NextInt(int maxExclusive)
        {
            if (maxExclusive <= 0)
                throw new ArgumentException($"Argument must be greater than zero", nameof(maxExclusive));

            // Calculate seeds
            var v5 = (int)(_state >> 0x3b);
            var v6 = (int)((_state ^ _state >> 0x12) >> 0x1b);

            // Advance state
            _state = _state * Multiplier + Increment;

            // Get final value
            v5 = (v6 << (-v5 & 0x1f)) + (v6 >> v5) >> 1;
            var v1 = v5 / maxExclusive;
            return v5 - v1 * maxExclusive;
        }
    }
}
