namespace Domain_Code;

public class Flight : Identifiable
{
    public Key FlightNumber { get; set; }
    public TimeOnly DepartureTime { get; set; }
    public TimeOnly ArrivalTime { get; set; }
    public string Connection { get; set; }
    public DateOnly FlightDate { get; set; }
    public string PlaneType { get; set; }
    
    public override Key GetId()
    {
        return FlightNumber;
    }
}