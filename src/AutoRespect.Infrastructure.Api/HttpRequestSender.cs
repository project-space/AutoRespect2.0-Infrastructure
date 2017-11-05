using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.Api.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;

namespace AutoRespect.Infrastructure.Api
{
    [DI(LifeCycle.Transient)]
    public class HttpRequestSender : IHttpRequestSender
    {
        private readonly HttpClient httpClient;

        public HttpRequestSender()
        {
            httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> Send(HttpRequestMessage request)
        {
            using (var cts = new CancellationTokenSource())
            {
                var response = await httpClient.SendAsync(request, cts.Token);

                return response;
            }
        }
    }
}
