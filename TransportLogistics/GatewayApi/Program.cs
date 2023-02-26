using Ocelot.Middleware;
using Ocelot.DependencyInjection;

var _corsOriginPolicy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddCors(options => 
         options.AddPolicy(name: _corsOriginPolicy,
                builder =>
                    { 
                       builder
                          .WithOrigins("http://localhost:7086")
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                    }));
builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();

app.UseCors("CorsPolicy");
await app.UseOcelot();
app.Run();
