namespace Domain_Code;

public class Customer : IIdentifiable
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    
    public object GetId()
    {
        return Id;
    }
}