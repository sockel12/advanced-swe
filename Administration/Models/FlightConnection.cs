namespace Administration.Models;

public record FlightConnection
{
    public string Airline { get; private set; }
    public Airport DepartureAirport { get; private set; }
    public Airport ArrivalAirport { get; private set; }
    public TimeOnly DepartureTime { get; private set; }
    public TimeOnly ArrivalTime { get; private set; }
    
    
    
    public FlightConnection(string airline, Airport departureAirport, Airport arrivalAirport, TimeOnly departureTime, TimeOnly arrivalTime)
    {
        Airline = airline;
        DepartureAirport = departureAirport;
        ArrivalAirport = arrivalAirport;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
    }
}