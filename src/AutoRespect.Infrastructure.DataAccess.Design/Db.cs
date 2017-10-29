using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoRespect.Infrastructure.DataAccess.Design
{
    public interface IDb
    {
        Task<int> Execute(Query query);
        Task<IEnumerable<T>> Query<T>(Query query);
        Task<T> QuerySingle<T>(Query query);
        Task<T> QuerySingleOrDefault<T>(Query query);
    }
}
