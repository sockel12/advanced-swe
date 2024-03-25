namespace Domain_Code;

public class Flight : Identifiable
{
    public Key FlightNumber { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public string Connection { get; set; }
    public DateTime FlightDate { get; set; }
    public string PlaneType { get; set; }
    
    public override Key GetId()
    {
        return FlightNumber;
    }
}