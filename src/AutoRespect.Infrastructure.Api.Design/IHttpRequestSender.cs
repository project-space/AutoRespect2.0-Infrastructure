using System.Net.Http;
using System.Threading.Tasks;

namespace AutoRespect.Infrastructure.Api.Design
{
    public interface IHttpRequestSender
    {
        Task<HttpResponseMessage> Send(HttpRequestMessage request);
    }
}
