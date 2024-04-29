namespace Domain_Code;

public class FlightClass : Identifiable
{
    public Key FClass { get; set; }
    public string Name { get; set; }

    public override Key GetId()
    {
        return FClass;
    }
}