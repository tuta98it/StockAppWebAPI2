using Microsoft.EntityFrameworkCore;
using StockAppWebAPI1.Models;
using StockAppWebAPI1.Repository;
using StockAppWebAPI1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var settings = builder.Configuration.GetRequiredSection("ConnectionStrings");
builder.Services.AddDbContext<StockAppContext>(options => options.UseSqlServer(settings["DefaultConnection"]));
// Repositores, services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
