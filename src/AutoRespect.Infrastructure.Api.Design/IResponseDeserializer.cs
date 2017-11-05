using System.Net.Http;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.Errors.Design;

namespace AutoRespect.Infrastructure.Api.Design
{
    public interface IResponseDeserializer
    {
        Task<R<T>> Deserialize<T>(HttpResponseMessage response);
    }
}
