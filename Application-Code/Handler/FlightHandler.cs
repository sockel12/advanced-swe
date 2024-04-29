namespace Application_Code.Handler;
using Application_Code.Interfaces;
using Domain_Code;



public class FlightHandler(IEntityManager entityManager) : BaseHandler<Flight>(entityManager)
{
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
        Repository.Add(flight);
        return flight;
    }
    
    public bool CancelFlight(string connectionId, string flightNumber)
    {
        Flight? flight = Repository.Get(new Key(flightNumber));
        if (flight == null) return false;
        if (flight.Connection != connectionId) return false;
        return Repository.Delete(new Key(flightNumber));
    }
    
}