using System.Collections;
using System.Collections.Immutable;
using Application_Code.Interfaces;
using Domain_Code;
using NotImplementedException = System.NotImplementedException;

namespace Adapter_Repositories;

public class Repository<T>(IEnumerable<IRepository<T>> Repositories) : IRepository<T>
    where T : Identifiable
{
    public int Count { get; private set; } = Repositories.Count();
    
    #region ICollectable
    public bool IsReadOnly => false;
    private int _currentRepo = 0;

    public IEnumerator<T> GetEnumerator()
    {
        return Repositories.Aggregate(Enumerable.Empty<T>(), (list, repository) => list.Concat(repository)).GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion ICollectable
    
    #region ICollection
    public void Add(T item)
    {
        Repositories.First().Add(item);
    }
    
    public void Add(params T[] items)
    {
        foreach (var repository in Repositories)
        {
            repository.Add(items);
        }
    }

    public void Clear()
    {
        foreach (var repository in Repositories)
        {
            repository.Clear();
        }
    }

    public bool Contains(T item) => Repositories.Any(repository => repository.Contains(item));

    public void CopyTo(T[] array, int arrayIndex)
    {
        
    }

    public bool Remove(T item) => Repositories.Aggregate(false, (b, repository) => b && repository.Remove(item));

    #endregion ICollection

    public bool Update(T item) => Repositories.Any(repository => repository.Update(item));
    public ImmutableList<T> GetAll()
    {
        return Repositories
            .Aggregate(new List<T>(), (list, repository) => list.Concat(repository.GetAll()).ToList())
            .ToImmutableList();
    }

    public T? Get(Key key)
    {
        return Repositories.FirstOrDefault(repository => repository.Get(key) != null)?.Get(key);
    }
    
    public bool Delete(Key key)
    {
        return Repositories.Any(repository => repository.Delete(key));
    }
}