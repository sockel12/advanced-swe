using System.Data.Odbc;

class DbOdbcConnection : IDbConnection
{
    private readonly OdbcConnection _odbcConnection;
    public DbOdbcConnection(OdbcConnection odbcConnection){
        _odbcConnection = odbcConnection;
        _odbcConnection.Open();
    }
    public void Dispose()
    {
        _odbcConnection.Dispose();
    }

    public QueryResult<T> Query<T>(Query<T> query)
    {
        OdbcCommand command = _odbcConnection.CreateCommand();
        command.CommandText = query.GetCmd();
        command.CommandType = System.Data.CommandType.Text;
        
        OdbcDataReader reader = command.ExecuteReader();
        QueryResult<T> result = new QueryResult<T>();

        while(reader.Read()){
            result.AddRecord(reader[0].ToString() ?? "Fail");
        }
        return result;
    }
}