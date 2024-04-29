using Application_Code.Interfaces;
using Domain_Code;

namespace Adapter_Repositories;

public class EntityManager : IEntityManager
{
    private readonly List<IRepositoryFactory> _repositoryFactories = new();
    public void RegisterRepositoryFactory(IRepositoryFactory factory)
    {
        _repositoryFactories.Add(factory);
    }
    public void UnregisterRepositoryFactory(IRepositoryFactory factory)
    {
        _repositoryFactories.Remove(factory);
    }
    
    
    public IRepository<T> GetRepository<T>()
        where T : Identifiable
    {
        return new Repository<T>(
            _repositoryFactories
                .Where(factory => factory.HasRecords<T>())
                .Select(factory => factory.GetRepository<T>())
        );
    }
}