using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Charges
{
    [MetaSerializable]
    public class ChargesFeatures
    {
        [MetaMember(1, 0)]
        public bool SupportsCharges { get; set; }
        [MetaMember(2, 0)]
        public int DefaultInitialCharges { get; set; }
        [MetaMember(3, 0)]
        public ChargeMergeBehavior MergeBehavior { get; set; }
	}
}
