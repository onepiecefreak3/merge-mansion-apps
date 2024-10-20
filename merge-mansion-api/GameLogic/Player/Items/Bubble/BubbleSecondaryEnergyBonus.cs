using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializableDerived(2)]
    [Obsolete("Replaced by BubbleAuxEnergyBonus.")]
    public class BubbleSecondaryEnergyBonus : IBubbleBonus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SecondaryEnergy { get; set; }

        public BubbleSecondaryEnergyBonus()
        {
        }

        public BubbleSecondaryEnergyBonus(int secondaryEnergy)
        {
        }
    }
}