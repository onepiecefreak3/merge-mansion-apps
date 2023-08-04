using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.Modifiers
{
    public abstract class BasePlayerModifier : IPlayerModifier
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime ActivatedAt { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration Duration { get; set; }

        protected BasePlayerModifier()
        {
        }
    }
}