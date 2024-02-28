namespace Domain_Code;

public class Carrier : IIdentifiable
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CarrCode { get; set; }
    public Uri Website { get; set; }
    
    public object GetId()
    {
        return Id;
    }
}