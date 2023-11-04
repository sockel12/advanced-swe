using System.Data;
using System.Data.Odbc;

namespace Adapter_Store.DbConnections;

public class OdbcConnector(string connectionString) : IDbConnector
{
    public string ConnectionString {get; private set;} = connectionString;
    /// <summary>
    /// Returns opened Odbc Connection
    /// </summary>
    /// <returns>Open Odbc Connection</returns>
    public IDbConnection GetConnection()
    {
       return new DbOdbcConnection(
        new OdbcConnection(ConnectionString)
       );
    }
}