using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum InboxItemStatus
    {
        Unread = 0,
        Read = 1,
        Actioned = 2
    }
}