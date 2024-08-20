using Metaplay.Core.Model;

namespace Metaplay.Core.League
{
    [MetaSerializable]
    [ModelActionExecuteFlags((ModelActionExecuteFlags)1)]
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