using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// 使用 builder.Configuration 來讀取資料庫連接字串
// string connectionString = builder.Configuration.GetConnectionString("DBContext");

// 註冊資料庫連接字串為單例
// builder.Services.AddSingleton(connectionString); // 註冊 Repository 和 介面IRepository
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IDatabaseRepository, DatabaseRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// Add services to the container.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
}
else
{
    builder.Services.AddControllersWithViews();
}
// builder.Services.AddControllersWithViews();
// builder.Services.AddControllersWithViews()
//                 .AddRazorRuntimeCompilation(); // 啟用 MVC 與 Razor 頁面的即時編譯

// builder.Services.AddRazorPages()
//                 .AddRazorRuntimeCompilation(); // 啟用 Razor Pages 即時編譯
var app = builder.Build();

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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
