using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaImplicitMembersRange(120, 140)]
    [ModelActionExecuteFlags((ModelActionExecuteFlags)4)]
    public abstract class PlayerSynchronizedServerActionBase : PlayerActionBase
    {
        protected PlayerSynchronizedServerActionBase()
        {
        }
    }
}