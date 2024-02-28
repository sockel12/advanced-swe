using Adapter_Repositories;
using Adapter_Store.DbConnections;
using Adapter_Store.TestObjects;
using Domain_Code;
using NHibernate;

namespace Adapter_Store;

public class DbController(IDbConnector connector, ISessionFactory factory) : IDatabase
{
    protected IDbConnector DbConnector = connector;
    protected ISessionFactory Factory = factory; // new DbSessionFactory().CreateSessionFactory()

    public IList<T> QueryAll<T>() where T : IIdentifiable
    {
        using var session = Factory.OpenSession();
        return session.CreateCriteria(typeof(T)).List<T>();
    }
    
    public bool Persist<T>(T obj) where T : IIdentifiable{
        using var session = Factory.OpenSession();
        session.Persist(obj);
        return false;
    }

    public bool Persist<T>(Repository<T> repository) where T : IIdentifiable
    {
        using var session = Factory.OpenSession();
        ITransaction transaction = session.BeginTransaction();
        repository.GetAll().ForEach(identifiable => session.Persist(identifiable));
        transaction.Commit();
        return true;
    }

    public Repository<T> Load<T>(T obj) where T : IIdentifiable
    {
        throw new NotImplementedException();
    }

    public int[] Upsert<T>(Repository<T> repository) where T : IIdentifiable
    {
        throw new NotImplementedException();
    }
}