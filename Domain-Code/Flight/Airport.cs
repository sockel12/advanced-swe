namespace Domain_Code;

public class Airport : Identifiable
{
    public Key AirportCode { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Timezone { get; set; }

    public override Key GetId()
    {
        return AirportCode;
    }
}