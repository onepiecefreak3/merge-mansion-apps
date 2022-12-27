using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Player
{
    public abstract class PlayerActionCore<TModel> : PlayerActionBase
    { }

    public abstract class PlayerActionBase : ModelAction<IPlayerModelBase>
    {
        public int Id { get; set; } // 0x10
    }
}
