using AutoRespect.Infrastructure.DataAccess.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Db;

namespace AutoRespect.Infrastructure.DataAccess
{
    [DI(LifeCycle.Singleton)]
    public class IdentityServerDb : Db, IIdentityServerDb
    {
        public IdentityServerDb(IDbConnectionStringGetter connectinStringGetter)
            : base (connectinStringGetter.Get(DbType.IdentityServer).Result)
        {            
        }
    }
}