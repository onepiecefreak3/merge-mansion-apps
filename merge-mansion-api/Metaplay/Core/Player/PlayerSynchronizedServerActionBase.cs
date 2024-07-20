using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [ModelActionExecuteFlags((ModelActionExecuteFlags)4)]
    [MetaImplicitMembersRange(120, 140)]
    public abstract class PlayerSynchronizedServerActionBase : PlayerActionBase
    {
        protected PlayerSynchronizedServerActionBase()
        {
        }
    }
}