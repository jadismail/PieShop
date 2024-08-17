using Microsoft.EntityFrameworkCore;
using PieShop.Models.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PieContext>(options => options.UseSqlite("PieShop"));
    
var app = builder.Build();


app.Run();