// See https://aka.ms/new-console-template for more information

using Adapter_Administration;
using Adapter_Repositories;
using Adapter_Store_CSV;
using Application_Code.Handler;
using Domain_Code;

public class Program
{
    public static void Main(string[] args)
    {

        EntityManager entityManager = new();
        entityManager.RegisterRepositoryFactory(
            new CsvRepositoryFactory()
        );

        ReservationHandler reservationHandler = new(entityManager);
        PlaneTypeHandler planeTypeHandler = new(entityManager);
        AirportHandler airportHandler = new(entityManager);
        CountryHandler countryHandler = new(entityManager);
        ConnectionHandler connectionHandler = new(entityManager);
        CustomerHandler customerHandler = new(entityManager);
        BookingHandler bookingHandler = new(entityManager);
        FlightHandler flightHandler = new(entityManager);
        
        IEnumerable<Route> reservationRoutes = new RouteBuilder("reservation")
            .Get(reservationHandler.GetAll)
            .Get("{id}", reservationHandler.Get)
            .Post("pay", reservationHandler.PayReservation)
            .Delete(reservationHandler.Delete)
            .Post("reserve", reservationHandler.ReserveBooking)
            .Build();
        
        IEnumerable<Route> planetypeRoutes = new RouteBuilder("planetype")
            .Get(planeTypeHandler.GetAll)
            .Get("{id}", planeTypeHandler.Get)
            .Post(planeTypeHandler.CreatePlaneType)
            .Put( planeTypeHandler.UpdatePlaneType)
            .Delete( planeTypeHandler.Delete)
            .Build();
        
        IEnumerable<Route> airportRoutes = new RouteBuilder("airport")
            .Get(airportHandler.GetAll)
            .Get("{id}", airportHandler.Get)
            .Post(airportHandler.CreateAirport)
            .Put( airportHandler.UpdateAirport)
            .Delete( airportHandler.Delete)
            .Build();
        
        IEnumerable<Route> countryRoutes = new RouteBuilder("country")
            .Get(countryHandler.GetAll)
            .Get("{id}", countryHandler.Get)
            .Post(countryHandler.CreateCountry)
            .Put( countryHandler.UpdateCountry)
            .Delete( countryHandler.Delete)
            .Build();
        
        IEnumerable<Route> connectionRoutes = new RouteBuilder("connection")
            .Get(connectionHandler.GetAll)
            .Get("{id}", connectionHandler.Get)
            .Post(connectionHandler.CreateConnection)
            .Put( connectionHandler.UpdateConnection)
            .Delete( connectionHandler.Delete)
            .Build();
        
        IEnumerable<Route> customerRoutes = new RouteBuilder("customer")
            .Get(customerHandler.GetAll)
            .Get("{id}", customerHandler.Get)
            .Post(customerHandler.CreateCustomer)
            .Put( customerHandler.UpdateCustomer)
            .Delete( customerHandler.Delete)
            .Build();

        IEnumerable<Route> bookingRoutes = new RouteBuilder("booking")
            .Get(bookingHandler.GetAll)
            .Get("{id}", bookingHandler.Get)
            .Post(bookingHandler.CreateBooking)
            .Build();

        IEnumerable<Route> flightRoutes = new RouteBuilder("flight")
            .Get(flightHandler.GetAll)
            .Get("{id}", flightHandler.Get)
            .Post(flightHandler.ScheduleFlight)
            .Delete(flightHandler.CancelFlight)
            .Build();
        
        IEnumerable<Route> routesV1 = new RouteBuilder("/api/v1")
            .SubRoute(reservationRoutes)
            .SubRoute(planetypeRoutes)
            .SubRoute(airportRoutes)
            .SubRoute(countryRoutes)
            .SubRoute(connectionRoutes)
            .SubRoute(customerRoutes)
            .SubRoute(bookingRoutes)
            .SubRoute(flightRoutes)
            .Build();
        
        Webserver webserver = new WebserverBuilder()
            .Routes(routesV1)
            .WithMockData()
            .UseSwagger()
            .Build();
        
        webserver.Start();
    }
    
}
