using Adapter_Store_CSV;
using Application_Code.Interfaces;
using CsvHelper.Configuration.Attributes;
using Domain_Code;

namespace Adapter_Administration;

public static class MockDataGenerator
{
    private static CsvRepositoryFactory _factory = new();
    private static IRepository<Customer> _repoCustomer;
    private static IRepository<Airport> _repoAirport;
    private static IRepository<Country> _repoCountry;
    private static IRepository<Connection> _repoConnection;
    private static IRepository<Flight> _repoFlight;
    private static IRepository<Booking> _repoBookings;
    private static IRepository<Carrier> _repoCarriers;
    
    
    public static void CreateMockData()
    {
        _repoCustomer = _factory.GetRepository<Customer>();
        _repoAirport = _factory.GetRepository<Airport>();
        _repoCountry = _factory.GetRepository<Country>();
        _repoConnection = _factory.GetRepository<Connection>();
        _repoFlight = _factory.GetRepository<Flight>();
        _repoBookings = _factory.GetRepository<Booking>();
        _repoCarriers = _factory.GetRepository<Carrier>();
        
        CreateMockCustomers();
        CreateMockCountries();
        CreateMockAirports();
        CreateMockConnections();
        CreateCarriers();
    }
    
    private static void CreateMockCustomers()
    {
        Customer c1 = new Customer()
        {
            Id = new Key("1"),
            FirstName = "Niklas",
            LastName = "Haas",
            PassportNumber = "000000000"
        };
        Customer c2 = new Customer()
        {
            Id = new Key("2"),
            FirstName = "Benjamin",
            LastName = "Appel",
            PassportNumber = "111111111"
        };
        _repoCustomer.Add(c1, c2);
    }

    private static void CreateMockCountries()
    {
        
        Country germany = new Country()
        {
            Id = new Key("DE"),
            Name = "Germany",
            Code = "DE"
        };
        Country usa = new Country()
        {
            Id = new Key("US"),
            Name = "United States of America",
            Code = "US"
        };
        _repoCountry.Add(germany, usa);
    }

    private static void CreateMockAirports()
    {
        
        Airport a1 = new Airport()
        {
            AirportCode = new Key("FRA"),
            Name = "Frankfurt Airport",
            City = "Frankfurt",
            Country = "DE",
            Timezone = "CET"
        };
        Airport a2 = new Airport()
        {
            AirportCode = new Key("LAX"),
            Name = "Los Angeles International Airport",
            City = "Los Angeles",
            Country = "US",
            Timezone = "PST"
        };
        _repoAirport.Add(a1, a2);
    }

    private static void CreateMockConnections()
    {
        
        Connection conn1 = new Connection()
        {
            Id = new Key("LH456"),
            AirportFrom = "FRA",
            AirportTo = "LAX",
            FlightDuration = 1275,
            Distance = 9090,
            DistanceUnit = DistanceUnit.KM,
        };
        Connection conn2 = new Connection()
        {
            Id = new Key("LH457"),
            AirportFrom = "LAX",
            AirportTo = "FRA",
            FlightDuration = 1275,
            Distance = 9090,
            DistanceUnit = DistanceUnit.KM,
        };
        _repoConnection.Add(conn1, conn2);
    }

    private static void CreateCarriers()
    {
        Carrier c1 = new Carrier()
        {
            CarrCode = new Key("LH"),
            Name = "Lufthansa",
            Country = "DE",
            Website = "lufthansa.com"
        };
        Carrier c2 = new Carrier()
        {
            CarrCode = new Key("AA"),
            Name = "American Airlines",
            Country = "US",
            Website = "aa.com"
        };
        _repoCarriers.Add(c1, c2);
    }
}