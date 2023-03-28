using ReportService.BusinessLogic.Services;
using TransportLogistics.Domain.Interfaces.Common;
using TransportLogistics.Domain.Interfaces.Reports.Services;

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
    services.AddScoped<IReportFormService, ReportFormService>();
    services.AddScoped<IOrderServicesDataRequester, OrderServicesDataRequester>();
}