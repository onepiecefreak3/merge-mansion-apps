using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.Modifiers
{
    [MetaSerializableDerived(1)]
    public class InfiniteEnergyPlayerModifier : BasePlayerModifier
    {
        private InfiniteEnergyPlayerModifier()
        {
        }

        public InfiniteEnergyPlayerModifier(MetaTime startTime, MetaDuration duration)
        {
        }
    }
}