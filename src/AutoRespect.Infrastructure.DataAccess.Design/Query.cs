namespace AutoRespect.Infrastructure.DataAccess.Design
{
    public class Query
    {
        public readonly string Sql;
        public readonly object Params;

        public Query(string @sql, object @params)
        {
            Sql    = @sql;
            Params = @params;
        }
    }
}
