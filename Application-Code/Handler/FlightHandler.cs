namespace Application_Code.Handler;
using Application_Code.Interfaces;
using Domain_Code;



public class FlightHandler(IEntityManager entityManager)
{
    private readonly IRepository<Flight> _flightRepository = entityManager.GetRepository<Flight>();

    public Flight? GetFlight(string id)
    {
        return _flightRepository.Get(new Key(id));
    }

    public IList<Flight> GetAllFlights()
    {
        return _flightRepository.GetAll();
    }
    public Flight ScheduleFlight(string connectionId, string flightNumber, DateOnly flightDate, TimeOnly departureTime, TimeOnly arrivalTime, string planetype)
    {
        Flight flight = new Flight()
        {
            FlightNumber = new Key(flightNumber),
            FlightDate = flightDate,
            DepartureTime = departureTime,
            ArrivalTime = arrivalTime,
            Connection = connectionId,
            PlaneType = planetype
        };
        _flightRepository.Add(flight);
        return flight;
    }
    
    public bool CancelFlight(string connectionId, string flightNumber)
    {
        Flight? flight = _flightRepository.Get(new Key(flightNumber));
        if (flight == null) return false;
        if (flight.Connection != connectionId) return false;
        return _flightRepository.Delete(new Key(flightNumber));
    }
    
}