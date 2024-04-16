using Adapter_Repositories;
using Adapter_Store_CSV;
using Application_Code.Interfaces;
using CsvHelper;

namespace Adapter_Administration;

internal enum Method
{
    GET,
    POST,
    PUT,
    UPDATE,
    DELETE
}

public class WebServer
{
    private WebApplication app;
    
    public WebServer(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        EntityManager manager = new EntityManager();
        manager.RegisterRepositoryFactory(new CsvRepositoryFactory());

        builder.Services.AddSingleton<IEntityManager>(manager);

        app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            MockDataGenerator.CreateMockData();
        }

    }
    
    public void Get(string path, Action action)
    {
        SetupRoute(path, action, Method.GET);
    }
    
    public void Post(string path, Action<object> action)
    {
        SetupRoute(path, action, Method.POST);

    }
    
    public void Put(string path, Action action)
    {
        SetupRoute(path, action, Method.PUT);
    }
    
    public void Update(string path, Action<object> action)
    {
        SetupRoute(path, action, Method.UPDATE);

    }
    
    public void Delete(string path, Action<object> action)
    {
        SetupRoute(path, action, Method.DELETE);

    }

    private void SetupRoute(string path, Delegate callback, Method method)
    {
        Func<string, Delegate, RouteHandlerBuilder> mapFunction;
        switch (method)
        {
            case Method.GET:
                mapFunction = app.MapGet;
                break;
            case Method.POST:
                mapFunction = app.MapPost;
                break;
            case Method.PUT:
                mapFunction = app.MapPut;
                break;
            case Method.UPDATE:
                mapFunction = app.MapPut;
                break;
            case Method.DELETE:
                mapFunction = app.MapDelete;
                break;
            default:
                return;
        }
        
        mapFunction(path, callback)
            .WithName($"{method.ToString()} {path}")
            .WithOpenApi();
    }

    public void Start()
    {        
        app.Run();
    }
}