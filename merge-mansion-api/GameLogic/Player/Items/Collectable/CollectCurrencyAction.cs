using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(1)]
    public class CollectCurrencyAction : ICollectAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ICalculateCollectValue ValueCalculator { get; set; }

        private CollectCurrencyAction()
        {
        }

        public CollectCurrencyAction(ICalculateCollectValue valueCalculator)
        {
        }
    }
}