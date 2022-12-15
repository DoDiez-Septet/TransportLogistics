global using Microsoft.EntityFrameworkCore;
global using OrderService.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(RepoEF<>));
builder.Services.AddScoped<IUserRepoEF, UserRepoEF>();

builder.Services.AddDbContextFactory<AppFactory>(
                options => options.UseSqlServer("name=ConnectionStrings:WebApiDatabase",
                x => x.MigrationsAssembly("OrderService.DataAccess")));


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
