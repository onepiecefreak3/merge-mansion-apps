using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class MergeMathBasedCollectValue : ICalculateCollectValue
    {
        [MetaMember(1, 0)]
        public Currencies Currency { get; set; }
        [MetaMember(2, 0)]
        public int Multiplier { get; set; }
    }
}
