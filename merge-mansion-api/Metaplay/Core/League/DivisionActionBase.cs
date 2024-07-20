using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [ModelActionExecuteFlags((ModelActionExecuteFlags)1)]
    [MetaSerializable]
    [MetaImplicitMembersRange(101, 200)]
    public abstract class DivisionActionBase : ModelAction<IDivisionModel>
    {
        [MetaMember(101, (MetaMemberFlags)0)]
        public EntityId InvokingParticipantId;
        [MetaMember(102, (MetaMemberFlags)0)]
        public EntityId InvokingPlayerId;
        protected DivisionActionBase()
        {
        }
    }
}