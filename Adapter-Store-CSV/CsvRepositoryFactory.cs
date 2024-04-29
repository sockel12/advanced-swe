using Application_Code.Interfaces;
using Domain_Code;

namespace Adapter_Store_CSV;

public class CsvRepositoryFactory : IRepositoryFactory
{

    private readonly Dictionary<Type, IRepository<Identifiable>> _repositories = new();
    public bool HasRecords<T>() where T : Identifiable
    {
        return true;
    }

    public IRepository<T> GetRepository<T>() where T : Identifiable => new Repository<T>();

    public IRepository<T> CreateRepository<T>() where T : Identifiable => new Repository<T>();
}