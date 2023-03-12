using Microsoft.Extensions.DependencyInjection.Extensions;
using CustomerService.BusinessLogic;
using CustomerService.DataAccess;

var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration = builder.Configuration;

// Add services to the container.
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(IServiceCollection services)
{
    //services.Add(configuration);
    services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddSingleton(configuration);
    services.AddCustomersDataAccess(configuration);
    services.AddCustomersBusinessLogic();
}