namespace Domain_Code;

public class Booking : Identifiable
{
    public Key BookingNumber { get; set; }
    public string Customer { get; set; }
    public string Flight { get; set; }
    public string FlightClass { get; set; }
    public int LuggageCount { get; set; }
    public double Price { get; set; }
    public DateTime BookingDate { get; set; }
    
    public override Key GetId()
    {
        return BookingNumber;
    }
}