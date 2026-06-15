using ReactIntegrationDemo.Api.Clients;
using ReactIntegrationDemo.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ErpApiClient>();
builder.Services.AddScoped<IntegrationService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactClient", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:5173");
    });
});

var app = builder.Build();

app.UseCors("ReactClient");

app.MapGet("/api/customers", async (IntegrationService integrationService) =>
{
    var customers = await integrationService.GetIntegratedCustomersAsync();
    return Results.Ok(customers);
});

app.Run();