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
        { typeof(Customer), new DomainConverter<Customer, CustomerDTO>() },
        { typeof(Flight), new DomainConverter<Flight, FlightDTO>()},
        { typeof(Airport), new DomainConverter<Airport, AirportDTO>()},
        { typeof(Booking), new DomainConverter<Booking, BookingDTO>()},
        { typeof(Connection), new DomainConverter<Connection, ConnectionDTO>()},
        { typeof(Country), new DomainConverter<Country, CountryDTO>()},
        { typeof(Carrier), new DomainConverter<Carrier, CarrierDTO>()}
    };

    private readonly Dictionary<Type, IRepository<Identifiable>> _repositories = new();
    public bool HasRecords<T>() where T : Identifiable
    {
        return true;
    }

    public IRepository<T> GetRepository<T>() where T : Identifiable
    {
        return new Repository<T>(_converters[typeof(T)]);
    }

    public IRepository<T> CreateRepository<T>() where T : Identifiable
    {
        return new Repository<T>(_converters[typeof(T)]);
    }
}