namespace Database;

public class DatabaseController(IDatabaseConnection databaseConnection)
{
    // private List<IDatabaseConnection> _databaseConnections = new();

    /* public bool AddDbConnection(IDatabaseConnection connection)
    {
        _databaseConnections.Add(connection);
        return true;
    } */
    public int TestConnection()
    {
        return databaseConnection.Query(
            new Query("Show tables;")
        );
    }
}