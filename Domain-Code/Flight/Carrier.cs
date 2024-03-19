namespace Domain_Code;

public class Carrier : Identifiable
{
    public Key CarrCode { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Website { get; set; }
    
    public override Key GetId()
    {
        return CarrCode;
    }
}