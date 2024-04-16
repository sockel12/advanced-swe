using Application_Code.Interfaces;
using Domain_Code;

namespace Adapter_Administration;

public static class Routes
{
    public static bool CreateRoutes(WebApplication app)
    {
        return CreateGetRoutes(app) && CreatePostRoutes(app);
    }
    
    private static bool CreateGetRoutes(WebApplication app){
        

        app.MapGet("/customers", (IEntityManager manager) =>
            {
                IRepository<Customer> customers = manager.GetRepository<Customer>();
                return customers.GetAll();
            })
            .WithName("GetCustomers")
            .WithOpenApi();

        app.MapGet("/airports", (IEntityManager manager) =>
            {
                IRepository<Airport> airports = manager.GetRepository<Airport>();
                return airports.GetAll();
            })
            .WithName("GetAirports")
            .WithOpenApi();

        app.MapGet("/connections", (IEntityManager manager) =>
            {
                IRepository<Connection> connections = manager.GetRepository<Connection>();
                return connections.GetAll();
            })
            .WithName("GetConnections")
            .WithOpenApi();
        
        app.MapGet("/carriers", (IEntityManager manager) =>
            {
                IRepository<Carrier> carriers = manager.GetRepository<Carrier>();
                return carriers.GetAll();
            })
            .WithName("GetCarriers")
            .WithOpenApi();
        
        app.MapGet("/flights", (IEntityManager manager) =>
            {
                IRepository<Flight> flights = manager.GetRepository<Flight>();
                return flights.GetAll();
            })
            .WithName("GetFlights")
            .WithOpenApi();


        return true;
    }
    
    private static bool CreatePostRoutes(WebApplication app)
    {
        app.MapPost("/customers", (IEntityManager manager, Customer customer) =>
            {
                IRepository<Customer> customers = manager.GetRepository<Customer>();
                // Get the data of the request
                customers.Add(customer);
                return customers;
            })
            .WithName("PostCustomers")
            .WithOpenApi();
        
        app.MapPost("/airports", (IEntityManager manager, Airport airport) =>
            {
                IRepository<Airport> airports = manager.GetRepository<Airport>();
                // Get the data of the request
                airports.Add(airport);
                return airports;
            })
            .WithName("PostAirports")
            .WithOpenApi();
        
        app.MapPost("/connections", (IEntityManager manager, Connection connection) =>
            {
                IRepository<Connection> connections = manager.GetRepository<Connection>();
                // Get the data of the request
                connections.Add(connection);
                return connections;
            })
            .WithName("PostConnections")
            .WithOpenApi();
        
        app.MapPost("/carriers", (IEntityManager manager, Carrier carrier) =>
            {
                IRepository<Carrier> carriers = manager.GetRepository<Carrier>();
                // Get the data of the request
                carriers.Add(carrier);
                return carriers;
            })
            .WithName("PostCarriers")
            .WithOpenApi();
        
        app.MapPost("/flights", (IEntityManager manager, Flight flight) =>
            {
                    IRepository<Flight> flights = manager.GetRepository<Flight>();
                // Get the data of the request
                flights.Add(flight);
                return flights;
            })
            .WithName("PostFlights")
            .WithOpenApi();
        
        
        return true;
    }
    
}