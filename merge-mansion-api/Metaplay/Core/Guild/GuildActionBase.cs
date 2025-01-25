using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace Metaplay.Core.Guild
{
    [ModelActionExecuteFlags((ModelActionExecuteFlags)1)]
    [MetaSerializable]
    public abstract class GuildActionBase : ModelAction<IGuildModelBase>
    {
        [IgnoreDataMember]
        public EntityId InvokingPlayerId;
        protected GuildActionBase()
        {
        }
    }
}