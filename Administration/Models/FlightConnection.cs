using Database.DbObjects;

namespace Administration.Models;

public record FlightConnection : IPersistable
{
    [PrimaryKey]
    public string ConnectionId { get; private set; }
    [PrimaryKey]
    public Association<Airline> Airline { get; private set; }
    
    public Association<Airport> DepartureAirport { get; private set; }
    public Association<Airport> DestinationAirport { get; private set; }
    public TimeOnly DepartureTime { get; private set; }
    public TimeOnly ArrivalTime { get; private set; }
    public int Distance { get; private set; }
    public string DistanceUnit { get; private set; }
    
    public FlightConnection(string connectionId, Association<Airline> airline, Association<Airport> departureAirport, Association<Airport> destinationAirport, TimeOnly departureTime, TimeOnly arrivalTime, int distance, string distanceUnit)
    {
        ConnectionId = connectionId;
        Airline = airline;
        DepartureAirport = departureAirport;
        DestinationAirport = destinationAirport;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
        Distance = distance;
        DistanceUnit = distanceUnit;
    }
}