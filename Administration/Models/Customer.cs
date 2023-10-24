namespace Administration.Models;

public record Customer
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }
    
    
    public Customer(string name, string email, string address, string city, string zipCode, string country)
    {
        Name = name;
        Email = email;
        Address = address;
        City = city;
        ZipCode = zipCode;
        Country = country;
    }
}