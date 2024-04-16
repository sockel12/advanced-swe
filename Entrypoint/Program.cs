// See https://aka.ms/new-console-template for more information

using Adapter_Administration;

public class Program
{
    public static void Main(string[] args)
    {
        Webserver webserver = new WebserverBuilder()
            .Route(new("/test", Method.GET, () => { return "{Test}"; }))
            .WithMockData()
            .UseSwagger()
            .Build();
        
        webserver.Start();
    }
    
}
