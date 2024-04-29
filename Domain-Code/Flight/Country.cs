namespace Domain_Code;

public class Country : Identifiable
{
    public Key Code { get; set; }
    public string Name { get; set; }
    
    public override Key GetId()
    {
        return Code;
    }
}