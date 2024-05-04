using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Travel.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TravelContextConnection") ?? throw new InvalidOperationException("Connection string 'TravelContextConnection' not found.");

builder.Services.AddDbContext<TravelContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<TravelUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TravelContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
