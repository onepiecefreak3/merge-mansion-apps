using GameLogic.Merge;
using GameLogic.Player.Board.Placement;
using GameLogic.Player.Items.Production;
using GameLogic.Random;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using Metaplay.Core;

namespace GameLogic.Player.Items.Activation
{
    [MetaSerializable]
    public class ActivationFeatures
    {
        [MetaMember(1)]
        public IItemSpawner ActivationSpawn { get; set; } // 0x10

        [MetaMember(2)]
        public IPlacement Placement { get; set; } // 0x18

        [MetaMember(3)]
        public IActivationCycle ActivationCycle { get; set; } // 0x20

        [MetaMember(4)]
        public int StorageMax { get; set; } // 0x28

        [MetaMember(5)]
        public IItemProducer DecayAfterLastCycleProducer { get; set; }

        [MetaMember(6)]
        public ItemVisibility SpawnVisibility { get; set; }

        [MetaMember(7)]
        public string OverrideSfx { get; set; }
        public bool Activable => ActivationSpawn != null && !(ActivationSpawn is EmptyProducer);

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return ActivationSpawn.TimeSkipPriceGems(context);
        }

        public static ActivationFeatures NoActivation;
        [MetaMember(8, (MetaMemberFlags)0)]
        public bool StartsFull { get; set; }
        public bool DecayAfterLastCycleAndActivation { get; }

        private ActivationFeatures()
        {
        }

        public ActivationFeatures(IItemSpawner activationSpawn, IPlacement placement, IActivationCycle cycle, int howManyCanStore, IItemProducer randomItemDecayProducer, string overrideSfx, bool startsFull, ItemVisibility itemVisibility)
        {
        }

        [MetaMember(9, (MetaMemberFlags)0)]
        private List<PlayerRequirement> ActivationRequirements { get; set; }
        public MetaTime? ActivationStartTime { get; }

        public ActivationFeatures(IItemSpawner activationSpawn, IPlacement placement, IActivationCycle cycle, int howManyCanStore, IItemProducer randomItemDecayProducer, string overrideSfx, bool startsFull, List<PlayerRequirement> activationRequirements, ItemVisibility itemVisibility)
        {
        }
    }
}