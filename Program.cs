using Microsoft.EntityFrameworkCore;
using PieShop.Models.Context;
using PieShop.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PieContext>(options => options.UseSqlite("PieShop"));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();