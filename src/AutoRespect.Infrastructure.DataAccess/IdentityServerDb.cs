using AutoRespect.Infrastructure.DataAccess.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Db;

namespace AutoRespect.Infrastructure.DataAccess
{
    [DI(LifeCycleType.Singleton)]
    public class IdentityServerDb : Db, IIdentityServerDb
    {
        public IdentityServerDb(IDbConnectinStringGetter connectinStringGetter)
            : base (connectinStringGetter.Get(DbType.IdentityServer).Result)
        {            
        }
    }
}