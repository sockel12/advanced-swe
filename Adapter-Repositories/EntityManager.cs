using Application_Code.Interfaces;
using Domain_Code;
using Type = System.Type;

namespace Adapter_Repositories;

public class EntityManager(IDatabase databaseController) : IEntityManager
{
    private Dictionary<Type, object> _repositories = new();
    private IDatabase _databaseController = databaseController;
    
    private Repository<T> GetRepository<T>()
        where T : IIdentifiable
    {
        Type type = typeof(T);
        if(!_repositories.ContainsKey(type))
        {
            _repositories.Add(
                type,
                new Repository<T>(_databaseController)
            );
        }
        return _repositories[type] as Repository<T>;
    }
    
    public void VisitRepository<T>(IRepositoryVisitor<T> visitor)
        where T : IIdentifiable
    {
        IRepository<T> repository = GetRepository<T>();
        repository.Accept(visitor);
    }
}