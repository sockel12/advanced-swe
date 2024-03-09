namespace Domain_Code;

public class BookingInvoice : IIdentifiable
{
    public Booking Booking { get; set; }
    public Key GetId()
    {
        return Booking.GetId();
    }
}