using Adapter_Store.StoreObjects;
using FluentNHibernate.Cfg.Db;

public abstract class DbConnection : PersistenceConfiguration<DbConnection, ConnectionStringBuilder>
{
    protected DbConnection(){
        CallDriver();
        CallDialect();
    }

    protected abstract void CallDriver();

    protected abstract void CallDialect();
}