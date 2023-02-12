global using Newtonsoft.Json;
global using Microsoft.EntityFrameworkCore;
global using OrderService.BusinessLogic;
global using OrderService.BusinessLogic.Services;
using OrderService.HandleExceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
