using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [MetaSerializable]
    public interface IMergeMansionAnalyticsEvent
    {
        AnalyticsEventType EventType { get; }

        string EventName { get; }
    }
}