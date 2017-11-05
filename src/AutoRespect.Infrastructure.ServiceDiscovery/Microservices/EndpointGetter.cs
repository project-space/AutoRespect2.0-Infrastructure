using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Microservices;
using Consul;

namespace AutoRespect.Infrastructure.ServiceDiscovery.Microservices
{
    [DI(LifeCycle.Singleton)]
    public class EndpointGetter : IEndpointGetter
    {
        private static readonly ConsulClient consul = new ConsulClient((config) =>
        {
            config.Address = new Uri("http://127.0.0.1:8500");
        });

        public async Task<string> Get(MicroserviceType microservice)
        {
            var microserviceName = MicroserviceTypeToName(microservice);
            var services = await consul.Catalog.Service(microserviceName);

            if (services.StatusCode == HttpStatusCode.OK)
            {
                if (services.Response.Length > 0)
                {
                    var service = services.Response.First();

                    return $"{service.ServiceAddress}:{service.ServicePort}";
                }
            }

            throw new Exception($"Сould not get endpoint to [{microserviceName}]");
        }

        private string MicroserviceTypeToName (MicroserviceType microservice)
        {
            switch (microservice)
            {
                case MicroserviceType.IdentityServer:
                    return "ms-identity-server";
                case MicroserviceType.ResourceServer:
                    return "ms-resource-server";
                default:
                    throw new Exception($"Unsupported microservice type {microservice}");
            }
        }
    }
}
