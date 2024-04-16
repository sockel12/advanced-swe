// See https://aka.ms/new-console-template for more information

using Adapter_Administration;

public class Program
{
    public static void Main(string[] args)
    {
        IEnumerable<Route> routes = new RouteBuilder("/api/v1")
            .Get("test", () => { return "Test"; })
            .Get("test/{id}", (string id) => { return id; })
            .Build();
            
        IEnumerable<Route> routesV2 = new RouteBuilder("/api/v2")
            .Get("test", () => { return "Test"; })
            .Get("test/{id}", (string id) => { return id; })
            .Build();
        
        Webserver webserver = new WebserverBuilder()
            .Routes(routes)
            .Routes(routesV2)
            .WithMockData()
            .UseSwagger()
            .Build();
        
        webserver.Start();
    }
    
}
