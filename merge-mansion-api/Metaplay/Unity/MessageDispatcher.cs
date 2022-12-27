using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Message;

namespace Metaplay.Metaplay.Unity
{
    public class MessageDispatcher : BasicMessageDispatcher
    {
        private MetaplayConnection _connection; // 0x38

        public MessageDispatcher(/*LogChannel log*/) : base(/*log*/)
        { }

        internal void SetConnection(MetaplayConnection connection)
        {
            _connection = connection;
        }

        internal void OnReceiveMessage(MetaMessage msg)
        {
            // Log debug "Receive: {msg}"

            var dispatched = DispatchMessage(msg);
            if (dispatched)
                return;

            // Log warning "No handlers for message {msg.GetType().Name}"
        }
    }
}
