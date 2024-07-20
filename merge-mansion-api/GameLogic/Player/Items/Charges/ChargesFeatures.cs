using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Charges
{
    [MetaSerializable]
    public class ChargesFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool SupportsCharges { get; set; }

        [MetaMember(2, 0)]
        public int DefaultInitialCharges { get; set; }

        [MetaMember(3, 0)]
        public ChargeMergeBehavior MergeBehavior { get; set; }

        public static ChargesFeatures NoCharges;
        public ChargesFeatures()
        {
        }

        public ChargesFeatures(bool supportsCharges, int defaultInitialCharges, ChargeMergeBehavior mergeBehavior)
        {
        }
    }
}