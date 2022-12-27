using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Network
{
    public class MetaHttpClient : IDisposable
    {
        public static readonly MetaHttpClient DefaultInstance = new MetaHttpClient(); // 0x0

        private readonly HttpClient _httpClient; // 0x10

        public MetaHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public Task<MetaHttpResponse> GetAsync(string requestUri)
        {
            return GetAsync(requestUri, CancellationToken.None);
        }

        public async Task<MetaHttpResponse> GetAsync(string requestUri, CancellationToken ct)
        {
            using var response = await _httpClient.GetAsync(requestUri, ct);
            var responseData = await response.Content.ReadAsByteArrayAsync(ct);

            return new MetaHttpResponse(response.StatusCode, responseData);
        }
    }
}
