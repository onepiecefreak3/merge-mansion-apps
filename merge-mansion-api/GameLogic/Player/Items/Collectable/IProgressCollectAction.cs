using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializable]
    public interface IProgressCollectAction : ICollectAction
    {
        int Progress { get; }
    }
}