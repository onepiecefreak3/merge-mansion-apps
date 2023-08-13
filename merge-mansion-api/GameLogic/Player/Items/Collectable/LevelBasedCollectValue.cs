using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(1)]
    public class LevelBasedCollectValue : ICalculateCollectValue
    {
        [MetaMember(1, 0)]
        public int Factor { get; set; }

        [MetaMember(2, 0)]
        public Currencies Currency { get; set; }

        private LevelBasedCollectValue()
        {
        }

        public LevelBasedCollectValue(Currencies currency, int multiplyFactor)
        {
        }
    }
}