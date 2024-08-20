using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializableDerived(3)]
    public class BubbleAuxEnergyBonus : IBubbleBonus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EnergyType EnergyType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public BubbleAuxEnergyBonus()
        {
        }

        public BubbleAuxEnergyBonus(EnergyType energyType, int amount)
        {
        }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Chance { get; set; }
    }
}