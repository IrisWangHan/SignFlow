var builder = WebApplication.CreateBuilder(args);

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
    pattern: "{controller=Index}/{action=Index}/{id?}");

app.Run();
