using Domain_Code;

namespace Application_Code.Interfaces;

public interface IRepository<T> : ICollection<T>
    where T : IIdentifiable
{
    public bool Update(T item);
    public T? Get(Key key);
}