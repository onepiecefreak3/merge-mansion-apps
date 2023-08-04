using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializable]
    public enum StorageActionType
    {
        Sum = 0,
        Reset = 1,
        PreserveRatio = 2
    }
}