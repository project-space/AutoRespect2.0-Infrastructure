using AutoRespect.Infrastructure.DataAccess.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Db;

namespace AutoRespect.Infrastructure.DataAccess
{
    [DI(LifeCycleType.Singleton)]
    public class ResourceServerDb : Db, IResourceServerDb
    {
        public ResourceServerDb(IDbConnectionStringGetter connectinStringGetter) 
            : base(connectinStringGetter.Get(DbType.ResourceServer).Result)
        {
        }
    }
}
