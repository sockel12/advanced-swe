using Adapter_Repositories;
using Adapter_Store.DbConnections;
using Adapter_Store.TestObjects;
using Application_Code.Interfaces;
using Domain_Code;
using NHibernate;

namespace Adapter_Store;

public class DbController(IDbConnector connector, ISessionFactory factory)
{
    protected IDbConnector DbConnector = connector;
    protected ISessionFactory Factory = factory; // new DbSessionFactory().CreateSessionFactory()

    public IList<T> QueryAll<T>() where T : Identifiable
    {
        using var session = Factory.OpenSession();
        return session.CreateCriteria(typeof(T)).List<T>();
    }
    
    public bool Persist<T>(T obj) where T : Identifiable{
        using var session = Factory.OpenSession();
        session.Persist(obj);
        return false;
    }

    public bool Persist<T>(IRepository<T> repository) where T : Identifiable
    {
        using var session = Factory.OpenSession();
        ITransaction transaction = session.BeginTransaction();
        foreach (var identifiable in repository)
        {
            session.Persist(identifiable);
        }
        transaction.Commit();
        return true;
    }

    public IRepository<T> Load<T>(T obj) where T : Identifiable
    {
        throw new NotImplementedException();
    }

    public int[] Upsert<T>(IRepository<T> repository) where T : Identifiable
    {
        throw new NotImplementedException();
    }
}