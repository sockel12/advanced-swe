using Database.DbObjects;

namespace Administration.Models;

public record Booking : IPersistable
{
    [PrimaryKey]
    public string Id { get; private set; }
    
    public DateOnly BookingDate { get; private set; }
    public Association<FlightConnection> Connection { get; private set; }
    public DateOnly FlightDate { get; private set; }
    public decimal FlightPrice { get; private set; }
    public Association<Currency> Currency { get; private set; }
    public Association<BookingStatus> BookingStatus { get; private set; }
    public Association<Airline> Carrier { get; private set; }
    public Association<Passenger> Customer { get; private set; }
    public Association<Travel> Travel { get; private set; }
    public Association<Flight> Flight { get; private set; }
    
    public Booking(string id, DateOnly bookingDate, Association<FlightConnection> connection, DateOnly flightDate, decimal flightPrice, Association<Currency> currency, Association<BookingStatus> bookingStatus, Association<Airline> carrier, Association<Passenger> customer, Association<Travel> travel, Association<Flight> flight)
    {
        Id = id;
        BookingDate = bookingDate;
        Connection = connection;
        FlightDate = flightDate;
        FlightPrice = flightPrice;
        Currency = currency;
        BookingStatus = bookingStatus;
        Carrier = carrier;
        Customer = customer;
        Travel = travel;
        Flight = flight;
    }
    
}