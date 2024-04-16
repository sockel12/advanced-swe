using System.Collections.Immutable;
using Application_Code.Interfaces;
using Domain_Code;

namespace Application_Code.Handler;

public class AirportHandler(IEntityManager entityManager)
{
    private readonly IRepository<Airport> _airportRepository = entityManager.GetRepository<Airport>();
    
    public bool CreateAirport(Airport airport)
    {
        _airportRepository.Add(airport);
        return true;
    }

    public bool DeleteAirport(string id)
    {
        return _airportRepository.Delete(new Key(id));
    }
    
    public bool UpdateAirport(Airport airport)
    {
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