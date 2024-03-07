using Application_Code.Interfaces;
using Domain_Code;

namespace Adapter_Repositories;

public class EntityManager : IEntityManager
{
    private readonly List<IRepositoryFactory> _factoriesFactories = new();
    public void RegisterRepositoryFactory(IRepositoryFactory factory)
    {
        _factoriesFactories.Add(factory);
    }
    public void UnregisterRepositoryFactory(IRepositoryFactory factory)
    {
        _factoriesFactories.Remove(factory);
    }
    public void VisitRepository<T>(IRepositoryVisitor<T> visitor)
        where T : IIdentifiable
    {
        IRepository<T> repository = GetRepository<T>();
        repository.Accept(visitor);
    }
    
    private IRepository<T>? GetRepository<T>()
        where T : IIdentifiable
    {
        return new Repository<T>(
            _factoriesFactories
                .Where(factory => factory.HasRecords<T>())
                .Select(factory => factory.GetRepository<T>())
        );
    }
}