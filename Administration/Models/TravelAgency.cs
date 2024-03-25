using Database.DbObjects;

namespace Administration.Models;

public record TravelAgency : IPersistable
{
    [PrimaryKey]
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Street { get; private set; }
    public string PostalCode { get; private set; }
    public string City { get; private set; }
    public string CountryCode { get; private set; }
    public string PhoneNumber { get; private set; }
    public string EMailAddress { get; private set; }
    public string WebAddress { get; private set; }
    
    public TravelAgency(string id, string name, string street, string postalCode, string city, string countryCode, string phoneNumber, string eMailAddress, string webAddress)
    {
        Id = id;
        Name = name;
        Street = street;
        PostalCode = postalCode;
        City = city;
        CountryCode = countryCode;
        PhoneNumber = phoneNumber;
        EMailAddress = eMailAddress;
        WebAddress = webAddress;
    }
}