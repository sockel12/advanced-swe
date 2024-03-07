using System.Collections;
using Application_Code.Interfaces;
using Domain_Code;
using NotImplementedException = System.NotImplementedException;

namespace Adapter_Repositories;

public class Repository<T>(IEnumerable<IRepository<T>> Repositories) : IRepository<T>
    where T : IIdentifiable
{
    public int Count { get; private set; } = Repositories.Count();
    public bool IsReadOnly => false;
    private int _currentRepo = 0;
    
    public void Accept(IRepositoryVisitor<T> visitor)
    {
        visitor.Visit(this);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Repositories.Aggregate(Enumerable.Empty<T>(), (list, repository) => list.Concat(repository)).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}