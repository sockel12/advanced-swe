using Database.DbObjects;

namespace Administration.Models;

public record FlightConnection : IPersistable
{
    public Association<Airline> Airline { get; private set; }
    public string ConnectionId { get; private set; }
    public Airport DepartureAirport { get; private set; }
    public Airport ArrivalAirport { get; private set; }
    public TimeOnly DepartureTime { get; private set; }
    public TimeOnly ArrivalTime { get; private set; }
    
    
    
    public FlightConnection(Association<Airline> airline, Airport departureAirport, Airport arrivalAirport, TimeOnly departureTime, TimeOnly arrivalTime)
    {
        Airline = airline;
        DepartureAirport = departureAirport;
        ArrivalAirport = arrivalAirport;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
    }

    public string GetPrimaryKey()
    {
        return Airline.Id + ConnectionId;
    }
}