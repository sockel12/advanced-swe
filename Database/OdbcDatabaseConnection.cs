using System.Data.Odbc;

namespace Database;

public class OdbcDatabaseConnection(string connectionString) : IDatabaseConnection
{
    private readonly OdbcConnection _connection = new(connectionString);

    public int Query(Query query)
    {
        OdbcCommand odbcCommand = query.GetOdbcCommand();
        using (_connection)
        {
            odbcCommand.Connection = _connection;
            _connection.Open();
            OdbcDataReader result = odbcCommand.ExecuteReader();
            return result.RecordsAffected;
        }
    }
}