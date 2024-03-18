namespace Domain_Code;

public class BookingInvoice : Identifiable
{
    public Booking Booking { get; set; }
    public override Key GetId()
    {
        return Booking.GetId();
    }
}