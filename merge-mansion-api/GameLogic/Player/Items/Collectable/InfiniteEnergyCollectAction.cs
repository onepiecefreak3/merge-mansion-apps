using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(5)]
    public class InfiniteEnergyCollectAction : ICollectAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaDuration Duration { get; set; }

        private InfiniteEnergyCollectAction()
        {
        }

        public InfiniteEnergyCollectAction(MetaDuration duration)
        {
        }
    }
}