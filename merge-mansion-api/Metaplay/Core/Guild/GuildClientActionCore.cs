using Metaplay.Core.Model;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    public abstract class GuildClientActionCore<TModel> : GuildClientActionBase
    {
        protected GuildClientActionCore()
        {
        }
    }
}