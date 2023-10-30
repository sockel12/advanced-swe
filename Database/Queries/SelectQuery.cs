using Database.DbObjects;
using IQueryable = Database.Queries.IQueryable;

namespace Database.Queries;

public class SelectQuery(IPersistable entity) : IQueryable
{
    public string GetQuery()
    {
        return String.Format("SELECT * FROM {}", entity.GetType().Name);
    }
}