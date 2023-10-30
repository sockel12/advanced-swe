using System.Data.Odbc;
using Database;

namespace Tests.Database;

public class TestDatabaseController
{
    private DatabaseController _controller;
    [SetUp]
    public void Setup()
    {
        // string MyConString = "DRIVER={ODBC Driver 18 for SQL Server};SERVER=localhost;PORT=3306;DATABASE=sys;USER=root;PASSWORD=;OPTION=3;";
        string MyConString = "DSN=MySql";
        _controller = new(
          new OdbcDatabaseConnection(MyConString)
        );
    }

    [Test]
    public void Test1()
    {
        Assert.That(_controller.TestConnection(), Is.EqualTo(0));
    }
}