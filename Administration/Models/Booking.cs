using Database.DbObjects;

namespace Administration.Models;

public record Booking : IPersistable
{
    [PrimaryKey]
    public string Id { get; private set; }
    
    public DateOnly BookingDate { get; private set; }
    public Association<FlightConnection> Connection { get; private set; }
    public DateOnly FlightDate { get; private set; }
    public Association<MoneyAmount> FlightPrice { get; private set; }
    public Association<BookingStatus> BookingStatus { get; private set; }
    public Association<Airline> Carrier { get; private set; }
    public Association<Passenger> Customer { get; private set; }
    public Association<Travel> Travel { get; private set; }
    public Association<Flight> Flight { get; private set; }
    
    public Booking(string id, DateOnly bookingDate, Association<FlightConnection> connection, DateOnly flightDate, Association<MoneyAmount> flightPrice, Association<BookingStatus> bookingStatus, Association<Airline> carrier, Association<Passenger> customer, Association<Travel> travel, Association<Flight> flight)
    {
        Id = id;
        BookingDate = bookingDate;
        Connection = connection;
        FlightDate = flightDate;
        FlightPrice = flightPrice;
        BookingStatus = bookingStatus;
        Carrier = carrier;
        Customer = customer;
        Travel = travel;
        Flight = flight;
    }
    
}