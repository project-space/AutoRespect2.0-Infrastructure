using System.Threading.Tasks;

namespace AutoRespect.Infrastructure.ServiceDiscovery.Design.Db
{
    public interface IDbConnectinStringGetter
    {
        Task<string> Get(DbType db);
    }
}
