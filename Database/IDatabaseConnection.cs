using IQueryable = Database.Queries.IQueryable;

namespace Database;

public interface IDatabaseConnection
{
    public int Query(IQueryable query);
}