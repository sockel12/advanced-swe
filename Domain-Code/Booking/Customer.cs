namespace Domain_Code;

public class Customer : Identifiable
{
    public Key Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    
    public override Key GetId()
    {
        return Id;
    }
}