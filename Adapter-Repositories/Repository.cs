using System.Net.Sockets;
using Application_Code.Interfaces;
using Domain_Code;

namespace Adapter_Repositories;

public class Repository<T>(IDatabase database) : IRepository<T>
    where T : IIdentifiable
{
    private Dictionary<object, T> _values = new ();
    private IDatabase _databaseController = database;

    public bool Add(T value)
    {
        return _values.TryAdd(value.GetId(), value);
    }

    public T? Get(object key)
    {
        return _values.GetValueOrDefault(key);
    }

    public List<T> GetAll()
    {
        return _values.Values.ToList();
    }

    public bool Update(object key, T value)
    {
        if (!_values.ContainsKey(value.GetId())) return false;
        
        _values.Remove(value.GetId());
        _values.Add(value.GetId(), value);
        return true;
    }

    public bool Delete(object key)
    {
        return _values.Remove(key);
    }
}