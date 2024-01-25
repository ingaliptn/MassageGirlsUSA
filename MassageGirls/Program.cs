using MassageGirls.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using RobotsTxt;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

////////
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
///
var connectionString = builder.Configuration.GetConnectionString("MassageGirlsOnlineConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
