using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Travel.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TravelContextConnection") ?? throw new InvalidOperationException("Connection string 'TravelContextConnection' not found.");

builder.Services.AddDbContext<TravelContext>(options => options.UseSqlServer(connectionString));

//ㄏノ嘿砞竚
builder.Services.AddDefaultIdentity<TravelUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = false; //ぃ璶―筿秎ン斑
    options.User.AllowedUserNameCharacters = null; // す砛ヴ才ノめ
}).AddEntityFrameworkStores<TravelContext>();

//盞絏砞竚
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; //ぶ计
    options.Password.RequireLowercase = true; //ぶ糶ダ
    options.Password.RequireUppercase = true; //ぶ糶ダ
    options.Password.RequireNonAlphanumeric = false; //ぃ惠璶獶计㎝獶ダ才腹
    //options.Password.RequiredLength = 8; // 程盞絏(箇砞6 max:100)
});



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
