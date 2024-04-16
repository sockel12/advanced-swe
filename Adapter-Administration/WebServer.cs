using Adapter_Repositories;
using Adapter_Store_CSV;
using Application_Code.Interfaces;

namespace Adapter_Administration;

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

        if (!Routes.CreateRoutes(app))
        {
            Console.WriteLine("Failed to create routes.");
        }
        
        if (app.Environment.IsDevelopment())
        {
            MockDataGenerator.CreateMockData();
        }

    }

    public void Start()
    {        
        app.Run();
    }
}