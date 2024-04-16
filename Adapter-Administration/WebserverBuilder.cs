using Microsoft.AspNetCore.Components.Web;

namespace Adapter_Administration;


public class Route(string path, Method method, Delegate action)
{
    public string path = path;
    public Method method = method;
    public Delegate action = action;
}

public class WebserverBuilder
{
    private List<Route> routes = new List<Route>();
    private bool useSwagger = false;
    private bool withMockData = false;
    
    public WebserverBuilder()
    {
    }
    
    public WebserverBuilder Route(string path, Method method, Delegate action)
    {
        routes.Add(new(path, method, action));
        return this;
    }
    
    public WebserverBuilder Route(Route route)
    {
        routes.Add(route);
        return this;
    }

    public WebserverBuilder UseSwagger()
    {
        useSwagger = true;
        return this;
    }
    
    public WebserverBuilder WithMockData()
    {
        this.withMockData = true;
        return this;
    }

    public Webserver Build()
    {
        Webserver webserver = new Webserver(useSwagger, withMockData);
        foreach (var route in routes)
        {
            webserver.AddRoute(route.path, route.action, route.method);
        }
        return webserver;
    }
}