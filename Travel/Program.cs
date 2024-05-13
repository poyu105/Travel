using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Travel.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TravelContextConnection") ?? throw new InvalidOperationException("Connection string 'TravelContextConnection' not found.");

builder.Services.AddDbContext<TravelContext>(options => options.UseSqlServer(connectionString));

//使用者名稱設置
builder.Services.AddDefaultIdentity<TravelUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = false; //不再要求電子郵件唯一
    options.User.AllowedUserNameCharacters = null; // 允許任何字符作為用戶名
}).AddEntityFrameworkStores<TravelContext>();
//.AddUserManager<CustomUserManager<TravelUser>>();

/*
// 使用者名稱設置，使用自訂的 CustomUserManager
builder.Services.AddScoped(typeof(UserManager<>), typeof(CustomUserManager<>));
builder.Services.AddScoped(typeof(SignInManager<>), typeof(SignInManager<>));
*/
/*
//使用者名稱設置
builder.Services.AddIdentity<TravelUser, IdentityRole>(options =>
{
    // 停用 UserName 和 Email 的正規化
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = null; // 允許任何字符
    options.User.RequireUniqueEmail = false; // 不需要 Email 正規化
})
.AddEntityFrameworkStores<TravelContext>()
.AddDefaultTokenProviders();
*/

//密碼設置
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; //至少一個數字
    options.Password.RequireLowercase = true; //至少一個小寫字母
    options.Password.RequireUppercase = true; //至少一個大寫字母
    options.Password.RequireNonAlphanumeric = false; //不需要非數字和非字母的符號
    //options.Password.RequiredLength = 8; // 最小密碼長度(預設6 max:100)
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
