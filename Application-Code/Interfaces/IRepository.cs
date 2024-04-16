using System.Collections;
using System.Collections.Immutable;
using Domain_Code;

namespace Application_Code.Interfaces;

public interface IRepository<T> : ICollection<T>
    where T : Identifiable
{
    public void Add(params T[] items);
    public bool Update(T item);
    public bool Delete(Key key);
    public ImmutableList<T> GetAll();
    public T? Get(Key key);
}