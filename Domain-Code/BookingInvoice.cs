namespace Domain_Code;

public class BookingInvoice : IIdentifiable
{
    public Booking Booking { get; set; }
    public object GetId()
    {
        return Booking.GetId();
    }
}