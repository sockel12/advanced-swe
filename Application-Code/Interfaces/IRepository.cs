using Domain_Code;

namespace Application_Code.Interfaces;

public interface IRepository<T>
    where T : IIdentifiable
{
    public void Accept(IRepositoryVisitor<T> visitor);
    public T? Get(object key);
    public List<T> GetAll();
    public bool Add(T value);
    public bool Update(T value);
    public bool Delete(object key);
}