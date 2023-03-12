global using Newtonsoft.Json;
global using Microsoft.EntityFrameworkCore;
global using OrderService.BusinessLogic;
global using OrderService.BusinessLogic.Services;
using OrderService.HandleExceptions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration config = builder.Configuration;
builder.Services.AddSingleton(config);

builder.Services.AddBusinessLogic();

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

app.UseExceptionHandlerMiddleware();

app.Run();
