namespace Domain_Code;

public class Customer : IIdentifiable
{
    public Key Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    
    public Key GetId()
    {
        return Id;
    }
}