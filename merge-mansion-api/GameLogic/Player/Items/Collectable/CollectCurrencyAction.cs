using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class CollectCurrencyAction : ICollectAction
    {
        [MetaMember(1, 0)]
        public ICalculateCollectValue ValueCalculator { get; set; }
    }
}
