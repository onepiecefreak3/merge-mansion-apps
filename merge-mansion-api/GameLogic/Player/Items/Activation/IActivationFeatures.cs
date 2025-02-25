using GameLogic.Player.Items.Production;
using GameLogic.Player.Board.Placement;
using System;
using GameLogic.Merge;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using Metaplay.Core;

namespace GameLogic.Player.Items.Activation
{
    public interface IActivationFeatures
    {
        IItemSpawner ActivationSpawn { get; }

        IPlacement Placement { get; }

        IActivationCycle ActivationCycle { get; }

        int StorageMax { get; }

        IItemProducer DecayAfterLastCycleProducer { get; }

        ItemVisibility SpawnVisibility { get; }

        bool StartsFull { get; }

        List<PlayerRequirement> ActivationRequirements { get; }

        int? ActivationCost { get; }

        bool ShowTapTextOnDiscovery { get; }

        bool AllowCooldownRemover { get; }

        bool AllowEnergyMode { get; }

        MetaDuration? DecayDelay { get; }

        bool Activable { get; }

        bool DecayAfterLastCycleAndActivation { get; }

        MetaTime? ActivationStartTime { get; }

        bool HasDecayDelay { get; }
    }
}