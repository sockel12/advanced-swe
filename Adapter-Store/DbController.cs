namespace Adapter_Store;

public class DbController
{
    private readonly IDbConnector _dbConnector;

    public DbController(IDbConnector connector){
        _dbConnector = connector;
    }

    public void Query(){
        using (IDbConnection connection = _dbConnector.GetConnection())
        {
            Console.WriteLine("Query Database");
            QueryResult<string> queryResult = connection.Query(new Query<string>());
            queryResult.records.ForEach(Console.WriteLine);
        }
    }
}