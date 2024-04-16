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
        IEnumerable<Route> reservationRoutes = new RouteBuilder("reservation")
            .Post("pay", reservationHandler.PayReservation)
            .Post("cancel", reservationHandler.CancelReservation)
            .Build();
        
        IEnumerable<Route> reservationRoutes2 = new RouteBuilder("reservation2")
            .Post("pay", reservationHandler.PayReservation)
            .Post("cancel", reservationHandler.CancelReservation)
            .Build();
        
        IEnumerable<Route> routesV1 = new RouteBuilder("/api/v1")
            .SubRoute(reservationRoutes)
            .SubRoute(reservationRoutes2)
            .Build();
        
        Webserver webserver = new WebserverBuilder()
            .Routes(routesV1)
            .WithMockData()
            .UseSwagger()
            .Build();
        
        webserver.Start();
    }
    
}
