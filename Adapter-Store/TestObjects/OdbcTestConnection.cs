using FluentNHibernate.Cfg.Db;

namespace Adapter_Store;

public class OdbcTestConnection :PersistenceConfiguration<OdbcTestConnection, FluentNHibernate.Cfg.Db.OdbcConnectionStringBuilder>
{
    protected OdbcTestConnection()
    {
        Driver<NHibernate.Driver.OdbcDriver>();
    }

    public static OdbcTestConnection MyDialect // <-- insert any name here
    {
        get
        {
            // insert the dialect you want to use
            return new OdbcTestConnection().Dialect<NHibernate.Dialect.MySQLDialect>();
        }
    }
}
