using Application_Code.Interfaces;
using Domain_Code;

namespace Adapter_Store_CSV;

public class CSVRepositoryFactory : IRepositoryFactory
{
    
    public bool HasRecords<T>() where T : IIdentifiable
    {
        return true;
    }

    public IRepository<T> GetRepository<T>() where T : IIdentifiable
    {
        return new Repository<T>();
    }

    public IRepository<T> CreateRepository<T>() where T : IIdentifiable
    {
        return new Repository<T>();
    }
}