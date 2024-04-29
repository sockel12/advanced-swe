using System.Collections.Immutable;
using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class AirportHandler(IEntityManager entityManager) : BaseHandler<Airport>(entityManager)
{
    
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
        Repository.Add(airport);
        return airport;
    }
    
    public bool UpdateAirport(string id, string name, string city, string country, string timezone)
    {
        Airport? airport = Repository.Get(new Key(id));
        if (airport is null) return false;
        airport.Name = name;
        airport.City = city;
        airport.Country = country;
        airport.Timezone = timezone;
        return Repository.Update(airport);
    }
    
}