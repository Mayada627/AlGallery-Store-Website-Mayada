
//using AlGallery.Data;
//using AlGallery.Interfaces;
//using AlGallery.Repositories;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Session;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddDbContext<AlGalleryDBContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));



//// Add Identity services
//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<AlGalleryDBContext>()
//    .AddDefaultTokenProviders();


////Redirection to login
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Login";
//});

//builder.Services.AddControllersWithViews();



//builder.Services.AddScoped<IProductRepo, ProductRepo>();
//builder.Services.AddScoped<ICartItemRepo, CartItemRepo>();
//builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
//builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
//builder.Services.AddScoped<IOrderItemRepo, OrderItemRepo>();
//builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
//builder.Services.AddScoped<IShipmentRepo, ShipmentRepo>();
//builder.Services.AddScoped<IOrderRepo, OrderRepo>();



//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

////Session
//app.UseSession();



//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Home}/{id?}");


//// Add Session

//public class Startup
//{
//    public Startup(IConfiguration configuration)
//    {
//        Configuration = configuration;
//    }

//    public IConfiguration Configuration { get; }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        services.AddSession(); // Add the session services
//        services.AddControllersWithViews();
//    }

//    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//    {
//        // ...

//        app.UseSession(); // Use the session middleware

//        // ...
//    }

//    app.Run();

//}

using AlGallery.Data;
using AlGallery.Interfaces;
using AlGallery.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AlGalleryDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

// Add Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AlGalleryDBContext>()
    .AddDefaultTokenProviders();

// Redirection to login
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
});

builder.Services.AddControllersWithViews();

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(80); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddScoped<IProductRepo, ProductRepo>();
//builder.Services.AddScoped<ICartItemRepo, CartItemRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IOrderItemRepo, OrderItemRepo>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<IShipmentRepo, ShipmentRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Use session middleware
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();

