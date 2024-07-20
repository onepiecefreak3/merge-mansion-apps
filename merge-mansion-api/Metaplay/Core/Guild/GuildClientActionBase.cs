using Metaplay.Core.Model;

namespace Metaplay.Core.Guild
{
    [ModelActionExecuteFlags((ModelActionExecuteFlags)4)]
    [MetaSerializable]
    public abstract class GuildClientActionBase : GuildActionBase
    {
        protected GuildClientActionBase()
        {
        }
    }
}