using Database.DbObjects;

namespace Administration.Models;

public record Customer : IPersistable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }
    
    
    public Customer(string id, string name, string email, string address, string city, string zipCode, string country)
    {
        Id = id;
        Name = name;
        Email = email;
        Address = address;
        City = city;
        ZipCode = zipCode;
        Country = country;
    }

    public string GetPrimaryKey()
    {
        return Id;
    }
}