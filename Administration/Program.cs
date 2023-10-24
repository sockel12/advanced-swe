using Administration.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// TODO: Uncomment when we use https. For now, we only use http
// app.UseHttpsRedirection();




app.MapGet("/airports", () =>
    {
        return new Airport[]{
            new Airport("EDDH"),
            new Airport("EDDL")
        };
    })
    .WithName("Get all airports")
    .WithOpenApi();


app.Run();