using Adapter_Store.DbConnections;
using Adapter_Store.TestObjects;
using NHibernate;

namespace Adapter_Store;

public class DbController
{
    protected IDbConnector _dbConnector;
    protected ISessionFactory _factory;

    public DbController(IDbConnector connector){
        _dbConnector = connector;
        _factory = new DbSessionFactory().CreateSessionFactory();

        
    }

    public IList<T> QueryAll<T>(){
        using(var session = _factory.OpenSession()){
            return session.CreateCriteria(typeof(T)).List<T>();
        }
    }

    public IList<Flight> QueryAll(){
        using(var session = _factory.OpenSession()){
            using(var transaction = session.BeginTransaction()){
                var Flight = new Flight(){ Id = "1", Connection = "1" };
                session.SaveOrUpdate(Flight);
                transaction.Commit();
            }

            using(session.BeginTransaction()){
                var flights = session.CreateCriteria(typeof(Flight)).List<Flight>();
                return flights;
            }
        }
    }

    
}