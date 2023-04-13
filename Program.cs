using System;

using BD9.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;   // пространство имен класса ApplicationContext
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//для DateTime
var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
});
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/LogIn/Login";
    options.AccessDeniedPath = "/LogIn/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddIdentity<User, IdentityRole>(options =>//настройка того, чтоб пароль был любым
{
    options.Password.RequiredLength = 0;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultTokenProviders();

var app = builder.Build();
app.UseStaticFiles();//Подключения
app.UseRouting();
app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;


    var db = serviceProvider.GetRequiredService<ApplicationContext>();
    await db.Database.EnsureDeletedAsync();//обнуление бд
    await db.Database.EnsureCreatedAsync();//cjplfybt базы данных
    await ApplicationContextSeed.InitializeDb(db);//заполнение базы данных

}
app.Run();