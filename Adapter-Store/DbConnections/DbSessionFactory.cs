using Adapter_Store.StoreObjects;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace Adapter_Store.DbConnections;

public class DbSessionFactory
{
    public ISessionFactory CreateSessionFactory()
    {
        return Fluently
            .Configure()
            .Database(
                OdbcTestConnection.MyDialect.ConnectionString("DSN=mysql")
                .Driver<NHibernate.Driver.OdbcDriver>()
                .Dialect<NHibernate.Dialect.MySQLDialect>()
            )
            .Mappings(
                m => m.FluentMappings.AddFromAssemblyOf<FlightMap>()
            ).BuildSessionFactory();
    }
}
