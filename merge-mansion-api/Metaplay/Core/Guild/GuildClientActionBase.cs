using Metaplay.Core.Model;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    [ModelActionExecuteFlags((ModelActionExecuteFlags)4)]
    public abstract class GuildClientActionBase : GuildActionBase
    {
        protected GuildClientActionBase()
        {
        }
    }
}