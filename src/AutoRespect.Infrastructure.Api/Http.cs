using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.Api.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.Errors.Design;
using Newtonsoft.Json;

namespace AutoRespect.Infrastructure.Api
{
    [DI(LifeCycle.Singleton)]
    public class Http : IHttp
    {
        private readonly IHttpRequestSender requestSender;
        private readonly IResponseDeserializer responseDeserializer;

        public Http(
            IHttpRequestSender requestSender,
            IResponseDeserializer responseDeserializer)
        {
            this.requestSender = requestSender;
            this.responseDeserializer = responseDeserializer;
        }

        public async Task<R<TResponse>> Get<TResponse>(string uri)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                var response = await requestSender.Send(request);
                var deserialized = await responseDeserializer.Deserialize<TResponse>(response);

                return deserialized;
            }
        }

        public async Task<R<TResponse>> Post<TBody, TResponse>(string uri, TBody body)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                var serializedBody = JsonConvert.SerializeObject(body);

                request.Content = new StringContent(serializedBody, Encoding.UTF8, "application/json");

                var response     = await requestSender.Send(request);
                var deserialized = await responseDeserializer.Deserialize<TResponse>(response);

                return deserialized;
            }
        }

        public Task<R<TResponse>> Put<TBody, TResponse>(string uri, TBody body) => throw new NotImplementedException();

        public Task<R<TResponse>> Delete<TResponse>(string uri) => throw new NotImplementedException();
    }
}
