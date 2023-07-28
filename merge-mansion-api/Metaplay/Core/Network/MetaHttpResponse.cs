using System;
using System.Net;

namespace Metaplay.Core.Network
{
    public class MetaHttpResponse : IDisposable // TypeDefIndex: 712
    {
        // Properties
        public HttpStatusCode StatusCode { get; set; }  // 0x10
        public byte[] Content { get; set; } // 0x18
        public bool IsSuccessStatusCode => (int)StatusCode - 200 < 100;

        public MetaHttpResponse(HttpStatusCode statusCode, byte[] content)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public void Dispose()
        {
            StatusCode = 0;
            Content = null;
        }

        public override string ToString()
        {
            return $"MetaHttpResponse: statusCode={StatusCode}, content length={Content.Length}";
        }
    }
}
