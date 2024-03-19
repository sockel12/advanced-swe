namespace Domain_Code;

public class Reservation : Identifiable
{
    public Key Id { get; set; }
    public string Booking { get; set; }
    public string Customer { get; set; }
    public DateTime ReservationDate { get; set; }
    public double PaidPrice { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    
    public override Key GetId()
    {
        return Id;
    }
}