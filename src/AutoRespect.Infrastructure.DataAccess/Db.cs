using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.DataAccess.Design;
using Dapper;

namespace AutoRespect.Infrastructure.DataAccess
{
    public class Db : IDb
    {
        private readonly string connectionString;

        public Db(string connectionString) => this.connectionString = connectionString;

        public async Task<int> Execute(Query query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteAsync(
                    query.Sql,
                    query.Params
                );
            }
        }

        public async Task<IEnumerable<T>> Query<T>(Query query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<T>(
                    query.Sql,
                    query.Params
                );
            }
        }

        public async Task<T> QuerySingle<T>(Query query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QuerySingleAsync<T>(
                    query.Sql,
                    query.Params
                );
            }
        }

        public async Task<T> QuerySingleOrDefault<T>(Query query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<T>(
                    query.Sql,
                    query.Params
                );
            }

        }
    }
}
