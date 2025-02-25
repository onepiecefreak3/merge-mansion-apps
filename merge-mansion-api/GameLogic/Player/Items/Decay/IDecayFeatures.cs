using System;
using Metaplay.Core;
using GameLogic.Player.Items.Production;

namespace GameLogic.Player.Items.Decay
{
    public interface IDecayFeatures
    {
        bool DoesDecay { get; }

        MetaDuration Lifetime { get; }

        IItemProducer ItemProducer { get; }

        DecayMergeMode DecayMergeMode { get; }

        bool DoesBoosterAccelerateDecay { get; }

        DecayInheritMode DecayInheritMode { get; }

        bool ShowDecayTimer { get; }

        bool ShowDecayVfx { get; }

        MetaDuration RemainingDurationForDecayVfx { get; }

        bool NeedsDecayState { get; }
    }
}