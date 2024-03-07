using Domain_Code;

namespace Application_Code.Interfaces;

public interface IRepositoryVisitor<T> : ICollection<T>
    where T : IIdentifiable
{
    public void Visit(IRepository<T> repository);
}