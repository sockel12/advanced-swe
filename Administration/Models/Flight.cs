using Database.DbObjects;

namespace Administration.Models;

public record Flight : IPersistable
{
    
    [PrimaryKey]
    public Association<Airline> Airline { get; private set; }
    [PrimaryKey]
    public DateOnly FlightDate { get; private set; }
    [PrimaryKey]
    public Association<FlightConnection> Connection { get; private set; }
    
    public int Price { get; private set; }
    public Association<Currency> Currency { get; private set; }
    public string PlaneType { get; private set; }
    public int MaximumSeats { get; private set; }
    public int OccupiedSeats { get; private set; }
    
    public Flight(Association<Airline> airline, DateOnly flightDate, Association<FlightConnection> connection, int price, Association<Currency> currency, string planeType, int maximumSeats, int occupiedSeats)
    {
        Airline = airline;
        FlightDate = flightDate;
        Connection = connection;
        Price = price;
        Currency = currency;
        PlaneType = planeType;
        MaximumSeats = maximumSeats;
        OccupiedSeats = occupiedSeats;
    }    
}