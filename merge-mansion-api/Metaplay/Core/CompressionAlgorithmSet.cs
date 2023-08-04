using System;
using Metaplay.Core.Model;

namespace Metaplay.Core
{
    public struct CompressionAlgorithmSet
    {
        [MetaMember(1, 0)]
        private uint _flags; // 0x0
        public bool Contains(CompressionAlgorithm algorithm)
        {
            return (ToBit(algorithm) & _flags) != 0;
        }

        public void Add(CompressionAlgorithm algorithm)
        {
            _flags |= ToBit(algorithm);
        }

        private uint ToBit(CompressionAlgorithm algorithm)
        {
            if (algorithm == CompressionAlgorithm.None)
                throw new ArgumentOutOfRangeException(nameof(algorithm), "None is not an algorithm");
            if ((int)algorithm - 1 >= 0x20)
                throw new ArgumentOutOfRangeException(nameof(algorithm));
            return 1u << ((int)algorithm - 1 & 0x1F);
        }
    }
}