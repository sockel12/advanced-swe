namespace Administration.Models;

public record Booking
{
    public string BookingNumber { get; private set; }
    public Flight Flight { get; private set; }
    public Customer Customer { get; private set; }
    public int NumberOfSeats { get; private set; }
    public Currency Currency { get; private set; }
}