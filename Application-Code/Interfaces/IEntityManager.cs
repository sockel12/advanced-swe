using Domain_Code;

namespace Application_Code.Interfaces;

public interface IEntityManager
{
    public IRepository<T> GetRepository<T>() where T : Identifiable;
    public void RegisterRepositoryFactory(IRepositoryFactory factory);
    public void UnregisterRepositoryFactory(IRepositoryFactory factory);
}