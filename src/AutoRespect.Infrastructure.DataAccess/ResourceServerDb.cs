using AutoRespect.Infrastructure.DataAccess.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;

namespace AutoRespect.Infrastructure.DataAccess
{
    [DI(LifeCycleType.Singleton)]
    public class ResourceServerDb : Db, IResourceServerDb
    {
        public ResourceServerDb() : base(@"
            Data Source=(localdb)\\mssqllocaldb; 
            Initial Catalog=AutoRespect.ResourceServer; 
            Integrated Security=SSPI;")
        {
        }
    }
}
