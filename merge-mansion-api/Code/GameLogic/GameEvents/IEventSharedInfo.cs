using System;

namespace Code.GameLogic.GameEvents
{
    public interface IEventSharedInfo
    {
        EventGroupId GroupId { get; }

        int Priority { get; }

        string SharedEventId { get; }
    }
}