using Database.DbObjects;

namespace Administration.Models;

public record Airline : IPersistable
{
    [PrimaryKey]
    public string AirlineCode { get; private set; }
    public string Name { get; private set; }
    public string Country { get; private set; }
    public Currency Currency { get; private set; }
    
    public Airline(string airlineCode, string name, string country, Currency currency)
    {
        AirlineCode = airlineCode;
        Name = name;
        Country = country;
        Currency = currency;
    }
}