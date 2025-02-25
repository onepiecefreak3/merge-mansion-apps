using GameLogic.Player.Items.Production;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Decay
{
    [MetaSerializable]
    public class DecayFeatures : IDecayFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool DoesDecay { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration Lifetime { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public IItemProducer ItemProducer { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public DecayMergeMode DecayMergeMode { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool DoesBoosterAccelerateDecay { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public DecayInheritMode DecayInheritMode { get; set; }

        public static DecayFeatures NoDecay;
        [Obsolete("Doesn't seem to be in use")]
        public static DecayFeatures NoDecayButInherit;
        [Obsolete("Doesn't seem to be in use")]
        public static DecayFeatures NoDecayButInheritAndSum;
        public bool NeedsDecayState { get; }

        public DecayFeatures(MetaDuration lifetime, IItemProducer producer, DecayMergeMode mergeMode, bool boosterAccelerates)
        {
        }

        public DecayFeatures(bool doesDecay, MetaDuration lifetime, IItemProducer itemProducer, DecayMergeMode decayMergeMode, DecayInheritMode decayInheritMode, bool doesBoosterAccelerateDecay)
        {
        }

        private DecayFeatures()
        {
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool ShowDecayTimer { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool ShowDecayVfx { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public MetaDuration RemainingDurationForDecayVfx { get; set; }

        public DecayFeatures(bool doesDecay, MetaDuration lifetime, IItemProducer itemProducer, DecayMergeMode decayMergeMode, DecayInheritMode decayInheritMode, bool showDecayTimer, bool showDecayVfx, MetaDuration remainingDurationForDecayVfx, bool doesBoosterAccelerateDecay)
        {
        }
    }
}