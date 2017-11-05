using System.Threading.Tasks;

namespace AutoRespect.Infrastructure.ServiceDiscovery.Design.Microservices
{
    public interface IEndpointGetter
    {
        Task<string> Get(MicroserviceType microservice);
    }
}
