using System;

namespace Metaplay.Core
{
    public class CopyableEvent<DerivedEventType, T1, T2, T3, T4>
    {
        private Action<T1, T2, T3, T4> _invoker;
        public CopyableEvent()
        {
        }
    }

    public class CopyableEvent<DerivedEventType, T1, T2, T3, T4, T5, T6, T7>
    {
        private Action<T1, T2, T3, T4, T5, T6, T7> _invoker;
        public CopyableEvent()
        {
        }
    }

    public class CopyableEvent<DerivedEventType, T1>
    {
        private Action<T1> _invoker;
        public CopyableEvent()
        {
        }
    }

    public class CopyableEvent<DerivedEventType>
    {
        private Action _invoker;
        public CopyableEvent()
        {
        }
    }
}