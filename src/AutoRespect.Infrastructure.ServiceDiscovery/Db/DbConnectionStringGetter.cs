using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Db;
using Consul;

namespace AutoRespect.Infrastructure.ServiceDiscovery.Db
{
    [DI(LifeCycleType.Singleton)]
    public class DbConnectionStringGetter : IDbConnectionStringGetter
    {
        private static readonly ConsulClient _consulClient = new ConsulClient((config) =>
        {
            config.Address = new Uri("http://127.0.0.1:8500");
        });

        public async Task<string> Get(DbType db)
        {
            var key = $"db/{DbTypeToKey(db)}/config/connection";
            var r = await _consulClient.KV.Get(key);
            if (r.StatusCode == HttpStatusCode.OK)
            {
                return Encoding.UTF8.GetString(r.Response.Value);
            }
            else
            {
                throw new Exception($"CANNOT GET RESPONSE FOR KEY [{key}]");
            }
        }

        private string DbTypeToKey(DbType db)
        {
            switch (db)
            {
                case DbType.IdentityServer:
                    return "identity-server";
                case DbType.ResourceServer:
                    return "resource-server";
                default:
                    throw new Exception("UNSUPPORTED DBTYPE");
            }
        }
    }
}
