using Code.GameLogic.Config;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializable]
    public abstract class PlayerRequirement : IValidatable, IPlayerRequirement
    {
        protected PlayerRequirement()
        {
        }
    }
}