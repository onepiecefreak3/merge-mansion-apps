using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum DialogMode
    {
        None = 0,
        GenericDialog = 1,
        CompactDialog = 2,
        SMS = 3,
        CompactBottomDialog = 4
    }
}