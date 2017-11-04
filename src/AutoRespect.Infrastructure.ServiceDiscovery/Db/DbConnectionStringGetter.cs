using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Db;
using Consul;

namespace AutoRespect.Infrastructure.ServiceDiscovery.Db
{
    [DI(LifeCycle.Singleton)]
    public class DbConnectionStringGetter : IDbConnectionStringGetter
    {
        private static readonly ConsulClient _consulClient = new ConsulClient((config) =>
        {
            config.Address = new Uri("http://127.0.0.1:8500");
        });

        public async Task<string> Get(DbType db)
        {
            var serviceName = DbTypeToServiceName(db);
            var services = await _consulClient.Catalog.Service(serviceName);

            if (services.StatusCode == HttpStatusCode.OK)
            {
                if (services.Response.Length > 0)
                {
                    return services.Response.First().ServiceAddress;
                }
            }

            throw new Exception($"Сould not get connection string to [{serviceName}]");
        }

        private string DbTypeToServiceName(DbType db)
        {
            switch (db)
            {
                case DbType.IdentityServer:
                    return "db-identity-server";
                case DbType.ResourceServer:
                    return "db-resource-server";
                default:
                    throw new Exception("UNSUPPORTED DBTYPE");
            }
        }
    }
}
