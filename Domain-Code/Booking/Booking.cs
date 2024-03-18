namespace Domain_Code;

public class Booking : IIdentifiable
{
    public Key BookingNumber { get; set; }
    public Customer Customer { get; set; }
    public Connection Connection { get; set; }
    public FlightClass FlightClass { get; set; }
    public int LugguageCount { get; set; }
    public double PaidPrice { get; set; }
    public DateTime BookingDate { get; set; }
    
    public Key GetId()
    {
        return BookingNumber;
    }
}