using System.Collections.Generic;
using Metaplay.GameLogic.MergeChains;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.GameLogic.Player.Items.Activation;
using Metaplay.GameLogic.Player.Items.Boosting;
using Metaplay.GameLogic.Player.Items.Bubble;
using Metaplay.GameLogic.Player.Items.Charges;
using Metaplay.GameLogic.Player.Items.Chest;
using Metaplay.GameLogic.Player.Items.Collectable;
using Metaplay.GameLogic.Player.Items.Consumption;
using Metaplay.GameLogic.Player.Items.Decay;
using Metaplay.GameLogic.Player.Items.Merging;
using Metaplay.GameLogic.Player.Items.Sink;
using Metaplay.GameLogic.Player.Items.Spawning;
using Metaplay.GameLogic.Player.Items.TimeContainer;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items
{
    public class ItemDefinition: IGameConfigData<ItemType>
    {
        [MetaMember(1)]
        public ItemType ConfigKey { get; set; } // 0x10
        [MetaMember(2)]
        public string PoolTag { get; set; } // 0x18
        [MetaMember(3)]
        public string SkinName { get; set; }    // 0x20
        [MetaMember(4)]
        public int LevelNumber { get; set; }    // 0x28
        [MetaMember(5)]
        public bool Movable { get; set; }   // 0x2C
        [MetaMember(6)]
        public F64 CostInDiamonds { get; set; } // 0x30
        [MetaMember(7)]
        private F64 AnchorPriceGems { get; set; }
        [MetaMember(8)]
        private F64 AnchorPriceCoins { get; set; }
        [MetaMember(9)]
        public F64 TimeSkipPriceGems { get; set; }  // 0x48
        [MetaMember(10)]
        public F64 UnlockOnBoardPriceGems { get; set; }
        [MetaMember(11)]
        public int ExperienceValue { get; set; }
        [MetaMember(12)]
        public MergeFeatures MergeFeatures { get; set; }    // 0x60
        [MetaMember(13)]
        public ActivationFeatures ActivationFeatures { get; set; }  // 0x68
        [MetaMember(14)]
        public SpawnFeatures SpawnFeatures { get; set; }
        [MetaMember(15)]
        public DecayFeatures DecayFeatures { get; set; }    // 0x78
        [MetaMember(16)]
        public ChestFeatures ChestFeatures { get; set; }
        [MetaMember(17)]
        public CollectableFeatures CollectableFeatures { get; set; }
        [MetaMember(18)]
        public BoosterFeatures BoosterFeatures { get; set; }
        [MetaMember(19)]
        public BubbleFeatures BubbleFeatures { get; set; }
        [MetaMember(20)]
        public SinkFeatures SinkFeatures { get; set; }
        [MetaMember(21)]
        public ConsumableFeatures ConsumableFeatures { get; set; }
        [MetaMember(22)]
        public PortalFeatures PortalFeatures { get; set; }
        [MetaMember(23)]
        public ChargesFeatures ChargesFeatures { get; set; }
        [MetaMember(24)]
        public TimeContainerFeatures TimeContainer { get; set; }
        [MetaMember(25)]
        public List<string> Tags { get; set; }
        [MetaMember(26)]
        public MetaRef<MergeChainDefinition> MergeChainRef { get; set; }
        [MetaMember(27)]
        public List<string> ConfirmableMergeResults { get; set; }
        [MetaMember(28)]
        private List<IDirectorAction> OnDiscoveredActions { get; set; }

        public IEnumerable<IDirectorAction> OnDiscovered => OnDiscoveredActions;
    }
}
