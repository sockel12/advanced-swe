namespace Domain_Code;

public class Connection : Identifiable
{
    public Key Id { get; set; }
    public string AirportFrom { get; set; }
    public string AirportTo { get; set; }
    public double FlightDuration { get; set; }
    public double Distance { get; set; }
    public string DistanceUnit { get; set; }
    
    public override Key GetId()
    {
        return Id;
    }
}