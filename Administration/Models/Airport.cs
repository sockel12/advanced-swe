using Database.DbObjects;

namespace Administration.Models;

public record Airport : IPersistable
{
    [PrimaryKey]
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    
    public Airport(string code, string name, string city, string country)
    {
        Code = code;
        Name = name;
        City = city;
        Country = country;
    }
}