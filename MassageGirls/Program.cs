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

////////Add trailing slash

var excludedTrailingSlashPaths = new[] { "/Service", "/robots.txt" };

app.Use(async (context, next) =>
{
    var request = context.Request;

    // Exclude paths for static files and specific files
    var excludedPaths = new[] { "/css/", "/images/", "/js/", "/lib/", "/favicon.ico", "/sitemap.xml" };

    // Exclude known file extensions
    var excludedExtensions = new[] { ".css", ".js", ".png", ".jpg", ".jpeg", ".gif", ".ico", ".xml", ".txt" };

    if (excludedPaths.Any(path => request.Path.StartsWithSegments(path, StringComparison.OrdinalIgnoreCase)) ||
        excludedExtensions.Any(ext => request.Path.Value.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
    {
        await next();
        return;
    }

    // Exclude paths from trailing slash logic
    if (excludedTrailingSlashPaths.Any(path => request.Path.StartsWithSegments(path, StringComparison.OrdinalIgnoreCase)))
    {
        await next();
        return;
    }

    // Redirect to URL with trailing slash if it doesn't have one
    if (!request.Path.Value.EndsWith("/"))
    {
        var newPath = request.Path + "/";
        var newUrl = $"{request.Scheme}://{request.Host}{newPath}{request.QueryString}";
        context.Response.Redirect(newUrl, permanent: true); // Use permanent redirect
        return;
    }

    await next();
});



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

app.Map("/robots.txt", subApp => {
    subApp.Run(async context => {
        context.Response.ContentType = "text/plain";
        await context.Response.SendFileAsync("wwwroot/robots.txt");
    });
});

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
    pattern: "booking/",
    defaults: new { controller = "Home", action = "Booking" });

app.MapControllerRoute(
    name: "thankYouRoute",
    pattern: "thankyou/",
    defaults: new { controller = "Home", action = "ThankYou" });

app.MapControllerRoute(
    name: "contactRoute",
    pattern: "contact/",
    defaults: new { controller = "Home", action = "Contact" });

app.MapControllerRoute(
    name: "errorRoute",
    pattern: "error/",
    defaults: new { controller = "Home", action = "Error" });

app.MapControllerRoute(
    name: "ourMassageGirlsRoute",
    pattern: "our-girls/",
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
///
//app.MapControllerRoute(
//    name: "serviceRoute",
//    pattern: "/Service/{action=Index}/{id?}",
//    defaults: new { controller = "Service" });

//app.MapControllerRoute(
//    name: "serviceRoute",
//    pattern: "{controller=Service}/{action=Index}",
//    defaults: new { controller = "Service", action = "Index" });

//app.MapControllerRoute(
//    name: "indexTownRoute",
//    pattern: "{controller=Service}/{action=IndexTown}",
//    defaults: new { controller = "Service", action = "IndexTown" });

//app.MapControllerRoute(
//    name: "indexMassageRoute",
//    pattern: "{controller=Service}/{action=IndexMassage}",
//    defaults: new { controller = "Service", action = "IndexMassage" });

//app.MapControllerRoute(
//    name: "createRoute",
//    pattern: "{controller=Service}/{action=Create}",
//    defaults: new { controller = "Service", action = "Create" });

//app.MapControllerRoute(
//    name: "editRoute",
//    pattern: "{controller=Service}/{action=Edit}/{id?}",
//    defaults: new { controller = "Service", action = "Edit" });

//app.MapControllerRoute(
//    name: "editTownRoute",
//    pattern: "{controller=Service}/{action=EditTown}/{id?}",
//    defaults: new { controller = "Service", action = "EditTown" });

//app.MapControllerRoute(
//    name: "editMassageRoute",
//    pattern: "{controller=Service}/{action=EditMassage}/{id?}",
//    defaults: new { controller = "Service", action = "EditMassage" });


////

app.Run();