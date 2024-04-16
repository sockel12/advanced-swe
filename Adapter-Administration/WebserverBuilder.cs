namespace Adapter_Administration;


public class Route(string path, Method method, Delegate action)
{
    public readonly string Path = path;
    public readonly Method Method = method;
    public readonly Delegate Action = action;
}

public class RouteBuilder
{
    private readonly string _rootPath;
    private readonly List<Route> _subRoutes = new();
    private readonly List<Route> _getCallbacks = new();
    private readonly List<Route> _postCallbacks = new();
    private readonly List<Route> _putCallbacks = new();
    private readonly List<Route> _deleteCallbacks = new();
    private readonly List<Route> _patchCallbacks = new();

    public RouteBuilder(string rootPath)
    {
        _rootPath = rootPath;
    }
    
    public RouteBuilder Get(Delegate callback)
    {
        _getCallbacks.Add(new($"{_rootPath}", Method.GET, callback));
        return this;
    }
    
    public RouteBuilder Get(string path, Delegate callback)
    {
        _getCallbacks.Add(new($"{_rootPath}/{path}", Method.GET, callback));
        return this;
    }
    
    public RouteBuilder Post(Delegate callback)
    {
        _postCallbacks.Add(new($"{_rootPath}", Method.POST, callback));
        return this;
    }
    
    public RouteBuilder Post(string path, Delegate callback)
    {
        _postCallbacks.Add(new($"{_rootPath}/{path}", Method.POST, callback));
        return this;
    }
    
    public RouteBuilder Put(Delegate callback)
    {
        _putCallbacks.Add(new($"{_rootPath}", Method.PUT, callback));
        return this;
    }
    
    public RouteBuilder Put(string path, Delegate callback)
    {
        _putCallbacks.Add(new($"{_rootPath}/{path}", Method.PUT, callback));
        return this;
    }
    
    public RouteBuilder Delete(Delegate callback)
    {
        _deleteCallbacks.Add(new($"{_rootPath}", Method.DELETE, callback));
        return this;
    }
    
    public RouteBuilder Delete(string path, Delegate callback)
    {
        _deleteCallbacks.Add(new($"{_rootPath}/{path}", Method.DELETE, callback));
        return this;
    }
    
    public RouteBuilder Patch(Delegate callback)
    {
        _patchCallbacks.Add(new($"{_rootPath}", Method.PATCH, callback));
        return this;
    }
    
    public RouteBuilder Patch(string path, Delegate callback)
    {
        _patchCallbacks.Add(new($"{_rootPath}/{path}", Method.PATCH, callback));
        return this;
    }

    public RouteBuilder SubRoute(IEnumerable<Route> routes)
    {
        foreach(var route in routes)
        {
            _subRoutes.Add(new($"{_rootPath}/{route.Path}", route.Method, route.Action));
        }
        return this;
    }
    
    public IEnumerable<Route> Build()
    {
        IEnumerable<Route> currentRoutes = _getCallbacks
            .Concat(_postCallbacks)
            .Concat(_putCallbacks)
            .Concat(_deleteCallbacks)
            .Concat(_patchCallbacks)
            .Concat(_subRoutes);
        return currentRoutes;
    }
    
}

public class WebserverBuilder
{
    private List<Route> _routes = new List<Route>();
    private bool _useSwagger = false;
    private bool _withMockData = false;
    
    public WebserverBuilder()
    {
    }
    
    public WebserverBuilder Route(string path, Method method, Delegate action)
    {
        _routes.Add(new(path, method, action));
        return this;
    }
    
    public WebserverBuilder Route(Route route)
    {
        _routes.Add(route);
        return this;
    }

    public WebserverBuilder Routes(IEnumerable<Route> routes)
    {
        this._routes.AddRange(routes);
        return this;
    }

    public WebserverBuilder UseSwagger()
    {
        _useSwagger = true;
        return this;
    }
    
    public WebserverBuilder WithMockData()
    {
        this._withMockData = true;
        return this;
    }
    
    public Webserver Build()
    {
        Webserver webserver = new Webserver(_useSwagger, _withMockData);
        foreach (var route in _routes)
        {
            webserver.AddRoute(route.Path, route.Action, route.Method);
        }
        return webserver;
    }
}