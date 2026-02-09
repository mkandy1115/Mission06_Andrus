using Mission06_Andrus.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

// Initialize the SQLite engine. This is required for EF Core SQLite to work properly.
SQLitePCL.Batteries_V2.Init();

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context
builder.Services.AddDbContext<AddMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")));

// build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
