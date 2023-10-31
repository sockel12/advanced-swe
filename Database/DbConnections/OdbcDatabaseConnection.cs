using System.Data.Odbc;
using IQueryable = Database.Queries.IQueryable;

namespace Database;

public class OdbcDatabaseConnection(string connectionString) : IDatabaseConnection
{
    private readonly OdbcConnection _connection = new(connectionString);

    public int Query(IQueryable query)
    {
        OdbcCommand odbcCommand = new(query.GetQuery());
        using (_connection)
        {
            odbcCommand.Connection = _connection;
            _connection.Open();
            OdbcDataReader result = odbcCommand.ExecuteReader();
            return result.RecordsAffected;
        }
    }
}