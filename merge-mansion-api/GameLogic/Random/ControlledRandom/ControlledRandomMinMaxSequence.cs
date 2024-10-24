using Metaplay.Core.Model;
using System;

namespace GameLogic.Random.ControlledRandom
{
    [MetaSerializable]
    public class ControlledRandomMinMaxSequence
    {
        private static int SwapAttemptPerWeight;
        [MetaMember(1, (MetaMemberFlags)0)]
        public ulong Seed { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Index { get; set; }

        private ControlledRandomMinMaxSequence()
        {
        }

        public ControlledRandomMinMaxSequence(ulong seed)
        {
        }
    }
}