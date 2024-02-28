using Domain_Code;

namespace Application_Code.Interfaces;

public interface IRepositoryVisitor<T>
    where T : IIdentifiable
{
    public void Visit(IRepository<T> repository);
}