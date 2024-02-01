using MassageGirls.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using RobotsTxt;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

////////
///
builder.Services.AddStaticRobotsTxt(b =>
{
    b
        .AddSection(section => section
        .AddUserAgent("Googlebot")
        .Disallow("/"))
        .AddSection(section => section
        .AddUserAgent("Bingbot")
        .Disallow("/"))

    .AddSitemap("http://serverpipe.pp.ua/sitemap.xml");

    return b;
});

////////


var connectionString = builder.Configuration.GetConnectionString("MassageGirlsOnlineConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

////////
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        const int durationInSeconds = 60 * 60 * 24 * 7;
        ctx.Context.Response.Headers[HeaderNames.CacheControl] =
            "public,max-age=" + durationInSeconds;
    }
});
app.UseRouting();

app.UseRobotsTxt();

///////

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

//app.MapControllersWithViews();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/");

app.MapControllerRoute(
    name: "bookingRoute",
    pattern: "Booking/",
    defaults: new { controller = "Home", action = "Booking" });

app.MapControllerRoute(
    name: "thankYouRoute",
    pattern: "ThankYou/",
    defaults: new { controller = "Home", action = "ThankYou" });

app.MapControllerRoute(
    name: "contactRoute",
    pattern: "Contact/",
    defaults: new { controller = "Home", action = "Contact" });

app.MapControllerRoute(
    name: "errorRoute",
    pattern: "Error/",
    defaults: new { controller = "Home", action = "Error" });

app.MapControllerRoute(
    name: "ourMassageGirlsRoute",
    pattern: "OurMassageGirls/",
    defaults: new { controller = "Home", action = "OurMassageGirls" });

////

app.MapControllerRoute(
    name: "profileRouteWithTown",
    pattern: "{townName}/profile/{girlName}/",
    defaults: new { controller = "Profile", action = "Profile" });

// Pattern without townName
app.MapControllerRoute(
    name: "profileRouteWithoutTown",
    pattern: "profile/{girlName}/",
    defaults: new { controller = "Profile", action = "ProfileMain" });

app.MapControllerRoute(
    name: "citiesRoute",
    pattern: "{townName}/{UrlName?}/",
    defaults: new { controller = "Cities", action = "Cities" }); 

app.MapControllerRoute(
    name: "citiesDefaultRoute",
    pattern: "{townName}/",
    defaults: new { controller = "Cities", action = "CitiesDefault" }); 

//// 

app.MapControllerRoute(
    name: "serviceRoute",
    pattern: "Service/",
    defaults: new { controller = "Service", action = "Index" });

app.MapControllerRoute(
    name: "createRoute",
    pattern: "Create/",
    defaults: new { controller = "Service", action = "Create" });

app.MapControllerRoute(
    name: "editRoute",
    pattern: "Edit/",
    defaults: new { controller = "Service", action = "Edit" });

app.MapControllerRoute(
    name: "editMassageRoute",
    pattern: "EditMassage/",
    defaults: new { controller = "Service", action = "EditMassage" });

app.MapControllerRoute(
    name: "editTownRoute",
    pattern: "EditTown/",
    defaults: new { controller = "Service", action = "EditTown" });

app.MapControllerRoute(
    name: "indexMassageRoute",
    pattern: "IndexMassage/",
    defaults: new { controller = "Service", action = "IndexMassage" });

app.MapControllerRoute(
    name: "indexTownRoute",
    pattern: "IndexTown/",
    defaults: new { controller = "Service", action = "IndexTown" });

////




app.Run();