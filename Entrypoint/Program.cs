// See https://aka.ms/new-console-template for more information

using Adapter_Administration;
using Adapter_Repositories;
using Adapter_Store_CSV;
using Application_Code.Handler;

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
        IEnumerable<Route> reservationRoutes = new RouteBuilder("reservation")
            .Post("pay", reservationHandler.PayReservation)
            .Post("cancel", reservationHandler.CancelReservation)
            .Build();
        
        IEnumerable<Route> planetypeRoutes = new RouteBuilder("planetype")
            .Get(planeTypeHandler.GetPlaneTypes)
            .Get("{id}", planeTypeHandler.GetPlaneType)
            .Post(planeTypeHandler.CreatePlaneType)
            .Put( planeTypeHandler.UpdatePlaneType)
            .Delete( planeTypeHandler.DeletePlaneType)
            .Build();
        
        IEnumerable<Route> airportRoutes = new RouteBuilder("airport")
            .Get(airportHandler.GetAllAirports)
            .Get("{id}", airportHandler.GetAirport)
            .Post(airportHandler.CreateAirport)
            .Put( airportHandler.UpdateAirport)
            .Delete( airportHandler.DeleteAirport)
            .Build();
        
        IEnumerable<Route> routesV1 = new RouteBuilder("/api/v1")
            .SubRoute(reservationRoutes)
            .SubRoute(planetypeRoutes)
            .SubRoute(airportRoutes)
            .Build();
        
        Webserver webserver = new WebserverBuilder()
            .Routes(routesV1)
            .WithMockData()
            .UseSwagger()
            .Build();
        
        webserver.Start();
    }
    
}
