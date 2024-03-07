using BookStoreMVC.DatabaseContext;
using BookStoreMVC.Interfaces;
using BookStoreMVC.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Ignore loop
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

// Inject service
builder.Services.AddScoped<ISerieService, SerieService>();
// Config db context
try
{
    var connectionString = builder.Configuration.GetConnectionString("DbBookStoreConnection") ?? throw new InvalidOperationException("Connection string 'DbBookStoreConnection' not found.");
    builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(connectionString));
} catch (InvalidOperationException ex)
{
    Debug.WriteLine(ex.Message);
}

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
); ;

app.UseStaticFiles();

app.Run();
