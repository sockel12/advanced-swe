namespace Domain_Code;

public class Carrier : Identifiable
{
    public Key Id { get; set; }
    public string Name { get; set; }
    public string CarrCode { get; set; }
    public Uri Website { get; set; }
    
    public override Key GetId()
    {
        return Id;
    }
}