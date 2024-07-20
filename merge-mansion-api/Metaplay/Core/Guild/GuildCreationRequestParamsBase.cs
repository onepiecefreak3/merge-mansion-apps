using Metaplay.Core.Model;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    [MetaReservedMembers(1, 100)]
    public abstract class GuildCreationRequestParamsBase
    {
        protected GuildCreationRequestParamsBase()
        {
        }
    }
}