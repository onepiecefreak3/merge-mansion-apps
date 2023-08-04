using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(5)]
    [MetaSerializable]
    public class InfiniteEnergyCollectAction : ICollectAction
    {
        [MetaMember(1)]
        public MetaDuration Duration { get; set; }

        private InfiniteEnergyCollectAction()
        {
        }

        public InfiniteEnergyCollectAction(MetaDuration duration)
        {
        }
    }
}