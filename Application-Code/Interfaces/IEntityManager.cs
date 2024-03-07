using Domain_Code;

namespace Application_Code.Interfaces;

public interface IEntityManager
{
    public void VisitRepository<T>(IRepositoryVisitor<T> visitor)
        where T : IIdentifiable;

    public void RegisterRepositoryFactory(IRepositoryFactory factory);
    public void UnregisterRepositoryFactory(IRepositoryFactory factory);
}