using IQueryable = Database.Queries.IQueryable;

namespace Database;

public class CsvConnection : IDatabaseConnection
{
    public int Query(IQueryable query)
    {
        throw new NotImplementedException();
    }
}