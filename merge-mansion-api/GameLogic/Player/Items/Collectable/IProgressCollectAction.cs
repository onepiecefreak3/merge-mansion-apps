namespace Metaplay.GameLogic.Player.Items.Collectable
{
    public interface IProgressCollectAction : ICollectAction
    {
        int Progress { get; }
    }
}
