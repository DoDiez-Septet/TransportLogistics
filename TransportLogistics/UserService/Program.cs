using CustomServices;
using UserService.BusinessLogic;
using UserService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Add services to the container.
ConfigureServices(builder.Services);

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddEndpointsApiExplorer();

    services.AddSingleton(configuration);
    services.AddUsersDataAccess(configuration);    
    services.AddUsersBusinessLogic();
    services.AddCustomIntegratedServices();
}