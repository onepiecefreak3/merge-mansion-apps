using Code.GameLogic.Config;

namespace GameLogic.Player.Requirements
{
    public abstract class PlayerRequirement : IValidatable, IPlayerRequirement
    {
        protected PlayerRequirement()
        {
        }
    }
}