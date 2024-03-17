using Adapter_Repositories;
using Adapter_Store_CSV.DTO;
using Application_Code.Interfaces;
using AutoMapper;
using Domain_Code;
using IDTO = Adapter_Repositories.IDTO;

namespace Adapter_Store_CSV;

public class CsvRepositoryFactory : IRepositoryFactory
{
    private readonly Dictionary<Type, IConverter> _converters = new ()
    {
        { typeof(Customer), new DomainConverter<Customer, CustomerDTO>() }
    };

    private readonly Dictionary<Type, IRepository<IIdentifiable>> _repositories = new();
    public bool HasRecords<T>() where T : IIdentifiable
    {
        return true;
    }

    public IRepository<T> GetRepository<T>() where T : IIdentifiable
    {
        return new Repository<T>(_converters[typeof(T)]);
    }

    public IRepository<T> CreateRepository<T>() where T : IIdentifiable
    {
        return new Repository<T>(_converters[typeof(T)]);
    }
}