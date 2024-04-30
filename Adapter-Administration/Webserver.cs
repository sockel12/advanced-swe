using Microsoft.AspNetCore.Diagnostics;

namespace Adapter_Administration;

public enum Method
{
    GET,
    POST,
    PUT,
    PATCH,
    DELETE
}
public class Webserver
{
    private WebApplication app;
    
    public Webserver(bool useSwagger, bool withMockData)
    {
        var builder = WebApplication.CreateBuilder();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.DocumentFilter<SwaggerPathModifier>();
        });
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

        app.UseExceptionHandler(applicationBuilder =>
            applicationBuilder.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>();
                context.Response.StatusCode = 418;
                await context.Response.WriteAsJsonAsync(new { error = exception?.Error.Message });
            }));

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
    
    public void Patch(string path, Delegate action)
    {
        AddRoute(path, action, Method.PATCH);

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
            case Method.PATCH:
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