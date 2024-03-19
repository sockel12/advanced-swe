namespace Domain_Code;

public class Country : Identifiable
{
    public Key Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    
    public override Key GetId()
    {
        return Id;
    }
}