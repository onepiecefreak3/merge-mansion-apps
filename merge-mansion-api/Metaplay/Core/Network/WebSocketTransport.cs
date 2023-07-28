namespace Metaplay.Core.Network
{
    public class WebSocketTransport /*: WireMessageTransport*/
    {
        public class CouldNotConnectError : MessageTransport.Error
        { }

        public class WebSocketError : MessageTransport.Error
        {
            public string Message { get; set; }

            public WebSocketError(string message)
            {
                Message = message;
            }
        }

        public class WebSocketClosedError : MessageTransport.Error
        {
            public int Code { get; set; }
            public string Reason { get; set; }
            public bool WasClean { get; set; }

            public WebSocketClosedError(int code, string reason, bool wasClean)
            {
                Code = code;
                Reason = reason;
                WasClean = wasClean;
            }
        }
    }
}
