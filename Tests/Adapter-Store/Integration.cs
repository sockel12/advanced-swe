using Adapter_Store;
using Adapter_Store.DbConnections;

namespace Tests;

public class Integration
{
    private DbController odbcController;
    [SetUp]
    public void Setup()
    {
        odbcController = new DbController(
            new OdbcConnector("DSN=mysql")
        );
    }

    [Test]
    public void Test1()
    {
        odbcController.QueryAll();
        Assert.Pass("Is Queryable");
    }
}