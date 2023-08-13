using Metaplay.Core.Model;

namespace GameLogic.Merge
{
    [MetaSerializable]
    public enum ItemVisibility
    {
        HiddenWithPartiallyVisibleInside = 0,
        PartiallyVisible = 1,
        Visible = 2,
        HiddenWithVisibleInside = 3
    }
}