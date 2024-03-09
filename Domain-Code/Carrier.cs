namespace Domain_Code;

public class Carrier : IIdentifiable
{
    public Key Id { get; set; }
    public string Name { get; set; }
    public string CarrCode { get; set; }
    public Uri Website { get; set; }
    
    public Key GetId()
    {
        return Id;
    }
}