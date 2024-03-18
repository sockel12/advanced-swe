namespace Domain_Code;

public class Flight : Identifiable
{
    public Key FlightNumber { get; set; }
    public Carrier Carrier { get; set; }
    public Connection Connection { get; set; }
    public DateOnly FlightDate { get; set; }
    public string PlaneType { get; set; }
    
    public override Key GetId()
    {
        return FlightNumber;
    }
}