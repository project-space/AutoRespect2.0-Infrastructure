using System.Threading.Tasks;
using AutoRespect.Infrastructure.Errors.Design;

namespace AutoRespect.Infrastructure.Api.Design
{
    /*
        HTTP клиент ответы которого представляют собой тип Result. 
        При успешном ответе (300 > code >= 200) Result будет являться указанным generic'ом
        При ошибках клиента (500 > code >= 400) Result будет являться списком ошибок (см. базовый тип Error из ErrorHandling)
        При ошибке сервера (500 >= code) Result будет списком с одной ошибкой (TODO: указать ошибку для 500)
    */

    public interface IHttp
    {
        Task<R<TResponse>> Get<TResponse>(string uri, HttpSettings settings = null);
        Task<R<TResponse>> Post<TBody, TResponse>(string uri, TBody body, HttpSettings settings = null);
        Task<R<TResponse>> Put<TBody, TResponse>(string uri, TBody body, HttpSettings settings = null);
        Task<R<TResponse>> Delete<TResponse>(string uri, HttpSettings settings = null);
    }
}
