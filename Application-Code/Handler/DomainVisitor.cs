using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class DomainVisitor<T> : IRepositoryVisitor<T>
    where T : IIdentifiable
{
    public IRepository<T> Repository { get; private set; }
    
    public void Visit(IRepository<T> repository)
    {
        Repository = repository;
    }

    public IRepository<T> GetRepository(IEntityManager entityManager)
    {
        entityManager.VisitRepository(this);
        return Repository;
    }
}