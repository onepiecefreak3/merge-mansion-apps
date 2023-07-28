using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Metaplay.Core.Message
{
    public delegate void MessageHandler<in T>(T msg);

    public abstract class BasicMessageDispatcher : IMessageDispatcher
    {
        public delegate void RequestCompleteFn(MetaResponseMessage msg, bool forceCancel);

        //private readonly LogChannel _log; // 0x10
        private Dictionary<Type, List<Delegate>> _handlers; // 0x18
        private Dictionary<Type, List<Delegate>> _updatedHandlers; // 0x20
        private ConcurrentDictionary<int, ValueTuple<RequestCompleteFn, bool>> _pendingRequests; // 0x28

        private bool _isDispatching; // 0x34

        protected BasicMessageDispatcher(/*LogChannel log*/)
        {
            _handlers = new Dictionary<Type, List<Delegate>>();
            _pendingRequests = new ConcurrentDictionary<int, (RequestCompleteFn, bool)>();
        }

        protected bool DispatchMessage(MetaMessage msg)
        {
            if (msg != null && msg is MetaResponseMessage resMsg)
                return DispatchResponse(resMsg);

            return DispatchDefault(msg);
        }

        private bool DispatchResponse(MetaResponseMessage msg)
        {
            var removed = _pendingRequests.TryRemove(msg.RequestId, out var value);
            if (!removed)
                return false;

            value.Item1(msg, false);
            return true;
        }

        private bool DispatchDefault(MetaMessage msg)
        {
            var hasHandlers = _handlers.TryGetValue(msg.GetType(), out var handlers);
            if (!hasHandlers)
                return false;

            _isDispatching = true;
            foreach (var handler in handlers)
                handler.DynamicInvoke(msg);

            _isDispatching = false;
            if (_updatedHandlers != null)
            {
                _handlers = _updatedHandlers;
                _updatedHandlers = null;
            }

            return true;
        }

        public bool InterceptMessage(MetaMessage msg)
        {
            if (msg == null)
                return false;

            if (msg is MetaResponseMessage resMsg)
            {
                if (_pendingRequests.TryGetValue(resMsg.RequestId, out var t) && t.Item1 != null)
                    return DispatchResponse(resMsg);
            }

            return false;
        }

        public void AddListener<T>(MessageHandler<T> handlerFunc)
        {
            var handlers = _isDispatching ? _handlers : _updatedHandlers ??= CopyHandlers();
            if (handlers.TryGetValue(typeof(T), out var handler))
            {
                handler.Add(handlerFunc);
                return;
            }

            handlers[typeof(T)] = new List<Delegate> { handlerFunc };
        }

        public void RemoveListener<T>(MessageHandler<T> handlerFunc)
        {
            var handlers = _isDispatching ? _handlers : _updatedHandlers ??= CopyHandlers();
            if (!handlers.TryGetValue(typeof(T), out var handler))
                return;

            handler.Remove(handlerFunc);
            if (handler.Count != 0)
                return;

            handlers.Remove(typeof(T));
        }

        private Dictionary<Type, List<Delegate>> CopyHandlers()
        {
            var result = new Dictionary<Type, List<Delegate>>(_handlers.Count);
            foreach (var handler in _handlers)
                result[handler.Key] = new List<Delegate>(handler.Value);

            return result;
        }
    }
}
