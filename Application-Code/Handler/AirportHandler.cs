using System.Collections.Immutable;
using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class AirportHandler(IEntityManager entityManager)
{
    private readonly IRepository<Airport> _airportRepository = entityManager.GetRepository<Airport>();
    
    public Airport CreateAirport(string airportCode, string name, string city, string country, string timezone)
    {
        Airport airport = new Airport()
        {
            AirportCode = new Key(airportCode),
            Name = name,
            City = city,
            Country = country,
            Timezone = timezone
        };
        _airportRepository.Add(airport);
        return airport;
    }

    public bool DeleteAirport(string id)
    {
        return _airportRepository.Delete(new Key(id));
    }
    
    public bool UpdateAirport(string id, string name, string city, string country, string timezone)
    {
        Airport? airport = _airportRepository.Get(new Key(id));
        if (airport is null) return false;
        airport.Name = name;
        airport.City = city;
        airport.Country = country;
        airport.Timezone = timezone;
        return _airportRepository.Update(airport);
    }
    
    public Airport GetAirport(string id)
    {
        return _airportRepository.Get(new Key(id))!;
    }
    
    public ImmutableArray<Airport> GetAllAirports()
    {
        return _airportRepository.GetAll().ToImmutableArray();
    }
    
}