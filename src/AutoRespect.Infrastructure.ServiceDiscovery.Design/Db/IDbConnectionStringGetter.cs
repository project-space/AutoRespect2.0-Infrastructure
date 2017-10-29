using System.Threading.Tasks;

namespace AutoRespect.Infrastructure.ServiceDiscovery.Design.Db
{
    public interface IDbConnectionStringGetter
    {
        Task<string> Get(DbType db);
    }
}
