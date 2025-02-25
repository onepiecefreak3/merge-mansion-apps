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
    [MetaBlockedMembers(new int[] { 7 })]
    [MetaSerializable]
    public class ActivationFeatures : IActivationFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public IItemSpawner ActivationSpawn { get; set; } // 0x10

        [MetaMember(2, (MetaMemberFlags)0)]
        public IPlacement Placement { get; set; } // 0x18

        [MetaMember(3, (MetaMemberFlags)0)]
        public IActivationCycle ActivationCycle { get; set; } // 0x20

        [MetaMember(4, (MetaMemberFlags)0)]
        public int StorageMax { get; set; } // 0x28

        [MetaMember(5, (MetaMemberFlags)0)]
        public IItemProducer DecayAfterLastCycleProducer { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public ItemVisibility SpawnVisibility { get; set; }
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
        public List<PlayerRequirement> ActivationRequirements { get; set; }
        public MetaTime? ActivationStartTime { get; }

        public ActivationFeatures(IItemSpawner activationSpawn, IPlacement placement, IActivationCycle cycle, int howManyCanStore, IItemProducer randomItemDecayProducer, string overrideSfx, bool startsFull, List<PlayerRequirement> activationRequirements, ItemVisibility itemVisibility)
        {
        }

        [MetaMember(10, (MetaMemberFlags)0)]
        public int? ActivationCost { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public bool ShowTapTextOnDiscovery { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public bool AllowCooldownRemover { get; set; }

        public ActivationFeatures(IItemSpawner activationSpawn, IPlacement placement, IActivationCycle cycle, int howManyCanStore, IItemProducer randomItemDecayProducer, bool startsFull, List<PlayerRequirement> activationRequirements, int? activationCost, bool showTapTextOnDiscovery, bool allowCooldownRemover, ItemVisibility itemVisibility)
        {
        }

        [MetaMember(13, (MetaMemberFlags)0)]
        public bool AllowEnergyMode { get; set; }

        public ActivationFeatures(IItemSpawner activationSpawn, IPlacement placement, IActivationCycle cycle, int howManyCanStore, IItemProducer randomItemDecayProducer, bool startsFull, List<PlayerRequirement> activationRequirements, int? activationCost, bool showTapTextOnDiscovery, bool allowCooldownRemover, bool allowEnergyMode, ItemVisibility itemVisibility)
        {
        }

        [MetaMember(14, (MetaMemberFlags)0)]
        public MetaDuration? DecayDelay { get; set; }
        public bool HasDecayDelay { get; }

        public ActivationFeatures(IItemSpawner activationSpawn, IPlacement placement, IActivationCycle cycle, int howManyCanStore, IItemProducer randomItemDecayProducer, bool startsFull, List<PlayerRequirement> activationRequirements, int? activationCost, bool showTapTextOnDiscovery, bool allowCooldownRemover, bool allowEnergyMode, MetaDuration? decayDelay, ItemVisibility itemVisibility)
        {
        }
    }
}