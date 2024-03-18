using Domain_Code;

namespace Application_Code.Interfaces;

public interface IEntityManager
{
    public IRepository<T> GetRepository<T>() where T : IIdentifiable;
    public void RegisterRepositoryFactory(IRepositoryFactory factory);
    public void UnregisterRepositoryFactory(IRepositoryFactory factory);
}