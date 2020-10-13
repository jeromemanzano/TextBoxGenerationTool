using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TextBoxGenerationTool.Services
{
    public class RestService : IRestService
    {
        private readonly HttpClient _httpClient;

        public RestService() 
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpStatusCode> VerifyUrl(string url, CancellationToken token)
        {
            var requestResponse = await _httpClient.GetAsync(new Uri(url)).ConfigureAwait(false);

            return requestResponse.StatusCode;
        }
    }
}
