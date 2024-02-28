using Domain_Code;

namespace Application_Code.Interfaces;

public interface IEntityManager
{
    public void VisitRepository<T>(IRepositoryVisitor<T> visitor)
        where T : IIdentifiable;
}