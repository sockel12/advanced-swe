namespace Domain_Code;

public class Connection : IIdentifiable
{
    public Key Id { get; set; }
    public Country CountryFrom { get; set; }
    public Country CountryTo { get; set; }
    public Airport AirportFrom { get; set; }
    public Airport AirportTo { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public double FlightDuration { get; set; }
    public double Distance { get; set; }
    public DistanceUnit DistanceUnit { get; set; }
    public int Period { get; set; }
    
    public Key GetId()
    {
        return Id;
    }
}