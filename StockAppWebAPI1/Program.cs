﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using StockAppWebAPI1.Models;
using StockAppWebAPI1.Repositories;
using StockAppWebAPI1.Filters;
using StockAppWebAPI1.Repository;
using StockAppWebAPI1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var settings = builder.Configuration
                .GetRequiredSection("ConnectionStrings"); //read data from appsettings.json
builder.Services.AddDbContext<StockAppContext>(options =>
        options.UseSqlServer(settings["DefaultConnection"]));
builder.Services.AddControllers();
//repositories, services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IWatchListRepository, WatchListRepository>();
builder.Services.AddScoped<IWatchListService, WatchListService>();

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();

builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();
builder.Services.AddScoped<IQuoteService, QuoteService>();

//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IOrderService, OrderService>();

//builder.Services.AddScoped<ICWRepository, CWRepository>();
//builder.Services.AddScoped<ICWService, CWService>();

builder.Services.AddScoped<JwtAuthorizeFilter>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký dịch vụ phân quyền
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};
webSocketOptions.AllowedOrigins.Add("*");
//app.UseMiddleware<WebSocketMiddleware>();
app.UseWebSockets(webSocketOptions);

app.Run();

/*

Giả sử client của viết bằng javascript, hiển thị thông tin 2 giá trị x, y thay đổi liên tục được gửi đến từ server, thông qua web socket
Server của tôi viết bằng asp .net core web api, sử dụng web socket. Khi client connect với server thông qua websocket, server định kỳ 2 giây 1 lần gửi giá trị x,y về cho client thông qua web socket
Hãy viết code cả client và server cho tôi
*/