using Microsoft.AspNetCore.Identity;
using PFuzzyArtShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PFuzzyArtShop.Models.IdentityModels;
using System;
using PlantShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FuzzyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PFuzzyArtShopContext")));

builder.Services.AddIdentity<FuzzyShopUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
})
    .AddEntityFrameworkStores<FuzzyContext>()
    .AddDefaultTokenProviders();

// Register the UserManager<FuzzyShopUser> service
builder.Services.AddScoped<UserManager<FuzzyShopUser>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await ConfigureIdentity.CreateAdminUserAsync(scope.ServiceProvider);
}

app.UseSession();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Book}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "page_sort",
    pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
