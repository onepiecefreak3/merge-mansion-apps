using System;

namespace Metaplay.Core.Analytics
{
    public class AnalyticsEventHandler<TContext, TEvent>
    {
        public static AnalyticsEventHandler<TContext, TEvent> NopHandler;
        private Action<TContext, TEvent> _eventHandler;
        public AnalyticsEventHandler(Action<TContext, TEvent> eventHandler)
        {
        }
    }
}