using Adapter_Repositories;
using Adapter_Store_CSV;
using Application_Code.Interfaces;
using Domain_Code;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

EntityManager manager = new EntityManager();
manager.RegisterRepositoryFactory(new CSVRepositoryFactory());

builder.Services.AddSingleton<IEntityManager>(manager);
var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();