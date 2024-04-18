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
        CreateFlights();
        CreateBookings();
    }
    
    private static void CreateMockCustomers()
    {
        Customer c1 = new Customer()
        {
            Id = new NumberKey(1),
            FirstName = "Niklas",
            LastName = "Haas",
            PassportNumber = "000000000"
        };
        Customer c2 = new Customer()
        {
            Id = new NumberKey(2),
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
            Code = new Key("DE"),
            Name = "Germany",
        };
        Country usa = new Country()
        {
            Code = new Key("US"),
            Name = "United States of America",
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

    private static void CreateFlights()
    {
        Flight f1 = new Flight()
        {
            FlightNumber = new Key("LH456-01"),
            Connection = "LH456",
            PlaneType = "A747",
            FlightDate = DateOnly.FromDayNumber(200000),
            DepartureTime = TimeOnly.Parse("12:00"),
            ArrivalTime = TimeOnly.Parse("21:00")
        };
        Flight f2 = new Flight()
        {
            FlightNumber = new Key("LH457-01"),
            Connection = "LH457",
            PlaneType = "A747",
            FlightDate = DateOnly.FromDayNumber(210000),
            DepartureTime = TimeOnly.Parse("11:00"),
            ArrivalTime = TimeOnly.Parse("01:00")
        };
        _repoFlight.Add(f1, f2);
    }

    private static void CreateBookings()
    {
        Booking b1 = new Booking()
        {
            BookingNumber = new NumberKey(1),
            Customer = "1",
            Flight = "LH456-01",
            BookingDate = DateTime.Now,
            FlightClass = FlightClass.Business,
            Price = 845.99,
            LuggageCount = 1
        };
        Booking b2 = new Booking()
        {
            BookingNumber = new NumberKey(1),
            Customer = "2",
            Flight = "LH456-01",
            BookingDate = DateTime.Now,
            FlightClass = FlightClass.FirstClass,
            Price = 1225.00,
            LuggageCount = 1
        };
        _repoBookings.Add(b1, b2);
    }
}