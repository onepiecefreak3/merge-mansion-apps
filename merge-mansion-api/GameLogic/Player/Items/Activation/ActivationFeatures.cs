using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Player.Board.Placement;
using Metaplay.GameLogic.Player.Items.Production;
using Metaplay.GameLogic.Random;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Activation
{
    public class ActivationFeatures
    {
        [MetaMember(1)]
        public IItemSpawner ActivationSpawn { get; set; }   // 0x10
        [MetaMember(2)]
        public IPlacement Placement { get; set; }   // 0x18
        [MetaMember(3)]
        public IActivationCycle ActivationCycle { get; set; }   // 0x20
        [MetaMember(4)]
        public int StorageMax { get; set; } // 0x28
        [MetaMember(5)]
        public IItemProducer DecayAfterLastCycleProducer { get; set; }
        [MetaMember(6)]
        public ItemVisibility SpawnVisibility { get; set; }

        public bool Activable => ActivationSpawn != null && !(ActivationSpawn is EmptyProducer);

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return ActivationSpawn.TimeSkipPriceGems(context);
        }
    }
}
