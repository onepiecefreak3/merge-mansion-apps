using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [ModelActionExecuteFlags((ModelActionExecuteFlags)1)]
    [MetaSerializable]
    [MetaImplicitMembersRange(100, 110)]
    public abstract class PlayerActionBase : ModelAction<IPlayerModelBase>
    {
        public int Id { get; set; } // 0x10

        protected PlayerActionBase()
        {
        }
    }
}