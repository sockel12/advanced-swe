using Domain_Code;

namespace Application_Code.Interfaces;

public interface IRepository<T>
    where T : IIdentifiable
{
    public T? Get(object key);
    public List<T> GetAll();
    public bool Add(T value);
    public bool Update(object key, T value);
    public bool Delete(object key);
}