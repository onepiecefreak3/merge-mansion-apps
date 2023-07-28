using System;
using System.Net;
using System.Threading.Tasks;
using Metaplay.Core.Network;

namespace Metaplay.Core.Config
{
    public class HttpBlobProvider : IBlobProvider
    {
        // Fields
        private MetaHttpClient _httpClient; // 0x10
        private string _primaryBaseUrl; // 0x18
        private string _secondaryBaseUrlMaybe; // 0x20
        private string _uriSuffix; // 0x28

        public HttpBlobProvider(MetaHttpClient client, MetaplayCdnAddress address, string uriSuffix)
        {
            _httpClient = client;
            _primaryBaseUrl = address.PrimaryBaseUrl;
            _secondaryBaseUrlMaybe = address.SecondaryBaseUrl;
            _uriSuffix = uriSuffix;
        }

        public void Dispose() { }

        private string GetUri(string baseUrl, string configName, string fileName)
        {
            return string.Concat(baseUrl, configName, "/", fileName, _uriSuffix);
        }

        private bool IsResponseOkAndHasContent(MetaHttpResponse responseMessage)
        {
            return responseMessage.IsSuccessStatusCode && responseMessage.Content != null;
        }

        private async Task<MetaHttpResponse> GetResponseWithContentAsync(string primaryUrl, string secondaryUrlMaybe, int primaryHeadStartMilliseconds = 1000)
        {
            // Get data from primary address
            var getTask = _httpClient.GetAsync(primaryUrl);
            var delayTask = Task.Delay(primaryHeadStartMilliseconds);

            await Task.WhenAny(delayTask, getTask);

            if (getTask.Status == TaskStatus.RanToCompletion)
            {
                if (IsResponseOkAndHasContent(getTask.Result))
                    return getTask.Result;
            }

            // Otherwise, start getting data from secondary address
            var getTask2 = secondaryUrlMaybe == null ?
                Task.FromException<MetaHttpResponse>(new NullReferenceException()) :
                _httpClient.GetAsync(secondaryUrlMaybe);

            var waitedTask = await Task.WhenAny(getTask, getTask2);

            var task = getTask2;
            if (waitedTask != getTask)
                task = getTask;

            if (waitedTask.Status == TaskStatus.RanToCompletion)
            {
                if (IsResponseOkAndHasContent(waitedTask.Result))
                {
                    task.ContinueWithDispose();
                    return waitedTask.Result;
                }
            }

            // Otherwise, get data from unfinished task to get data
            await Task.WhenAny(task);

            if (task.Status == TaskStatus.RanToCompletion)
            {
                if (IsResponseOkAndHasContent(task.Result))
                {
                    waitedTask.ContinueWithDispose();
                    return task.Result;
                }
            }

            if (getTask.IsFaulted)
            {
                getTask2.ContinueWithDispose();
                throw getTask.Exception;
            }

            getTask2.ContinueWithDispose();
            getTask.ContinueWithDispose();

            throw new WebException("did not get suitable content response");
        }

        public async Task<byte[]> GetAsync(string configName, ContentHash version)
        {
            var primaryUri = GetUri(_primaryBaseUrl, configName, version.ToString());
            var secondaryUri = _secondaryBaseUrlMaybe;
            if (secondaryUri != null)
                secondaryUri = GetUri(_secondaryBaseUrlMaybe, configName, version.ToString());

            using var response = await GetResponseWithContentAsync(primaryUri, secondaryUri);
            return response.Content;
        }

        public Task<bool> PutAsync(string configName, ContentHash version, byte[] value)
        {
            throw new InvalidOperationException(string.Concat("HttpBlobProvider.PutAsync(", configName, "): operation not supported"));
        }
    }
}
