using Domain_Code;

namespace Application_Code.Interfaces;

public interface IRepository<T> : IEnumerable<T>
    where T : IIdentifiable
{
    public void Accept(IRepositoryVisitor<T> visitor);
}