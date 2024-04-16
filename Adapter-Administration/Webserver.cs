using Adapter_Repositories;
using Adapter_Store_CSV;
using Application_Code.Interfaces;
using CsvHelper;

namespace Adapter_Administration;

public enum Method
{
    GET,
    POST,
    PUT,
    UPDATE,
    DELETE
}

public class Webserver
{
    private WebApplication app;
    
    public Webserver(bool useSwagger, bool withMockData)
    {
        var builder = WebApplication.CreateBuilder();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        app = builder.Build();

        // Configure the HTTP request pipeline.
        if (useSwagger)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        if (withMockData)
        {
            MockDataGenerator.CreateMockData();
        }

    }
    
    public void Get(string path, Delegate action)
    {
        AddRoute(path, action, Method.GET);
    }
    
    public void Post(string path, Delegate action)
    {
        AddRoute(path, action, Method.POST);

    }
    
    public void Put(string path, Delegate action)
    {
        AddRoute(path, action, Method.PUT);
    }
    
    public void Update(string path, Delegate action)
    {
        AddRoute(path, action, Method.UPDATE);

    }
    
    public void Delete(string path, Delegate action)
    {
        AddRoute(path, action, Method.DELETE);

    }

    public void AddRoute(string path, Delegate callback, Method method)
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