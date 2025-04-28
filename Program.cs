using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PieShop.Models.Context;
using PieShop.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PieShop")));

builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(ShoppingCart.GetCart);
builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();