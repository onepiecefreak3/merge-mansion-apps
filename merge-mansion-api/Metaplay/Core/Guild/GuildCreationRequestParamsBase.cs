using Metaplay.Core.Model;

namespace Metaplay.Core.Guild
{
    [MetaReservedMembers(1, 100)]
    [MetaSerializable]
    public abstract class GuildCreationRequestParamsBase
    {
        protected GuildCreationRequestParamsBase()
        {
        }
    }
}