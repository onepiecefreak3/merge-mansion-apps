using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    [ModelActionExecuteFlags((ModelActionExecuteFlags)1)]
    public abstract class GuildActionBase : ModelAction<IGuildModelBase>
    {
        [IgnoreDataMember]
        public EntityId InvokingPlayerId;
        protected GuildActionBase()
        {
        }
    }
}