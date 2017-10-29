using AutoRespect.Infrastructure.DataAccess.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;

namespace AutoRespect.Infrastructure.DataAccess
{
    [DI(LifeCycleType.Singleton)]
    public class IdentityServerDb : Db, IIdentityServerDb
    {
        public IdentityServerDb() : base(@"
            Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=AutoRespect.IdentityServer;
            Integrated Security=SSPI;")
        {
        }
    }
}
