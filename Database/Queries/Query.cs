using IQueryable = Database.Queries.IQueryable;

namespace Database;

public class Query(string query) : IQueryable
{
    public string GetQuery()
    {
        return query;
    }
}