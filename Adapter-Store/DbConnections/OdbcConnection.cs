using System.Data.Odbc;
using Adapter_Store.StoreObjects;

class DbOdbcConnection : DbConnection
{
    private readonly OdbcConnection _odbcConnection;
    public DbOdbcConnection(OdbcConnection odbcConnection){
        _odbcConnection = odbcConnection;
        _odbcConnection.Open();
    }

    protected override void CallDialect()
    {
        Driver<NHibernate.Driver.OdbcDriver>();
    }

    protected override void CallDriver()
    {
        Dialect<NHibernate.Dialect.MySQLDialect>();
    }
}