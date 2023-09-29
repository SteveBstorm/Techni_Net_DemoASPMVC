using DemoASPMVC.Services;
using DemoASPMVC.Tools;
using DemoASPMVC_DAL.Interface;
using DemoASPMVC_DAL.Services;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Enregistrement des services au niveau global de l'application
//Singleton => Garder une seule et unique instance pour la dur�e de vie de l'application
// Service r�-instancier � chaque fois qu'on red�marre l'application


builder.Services.AddSingleton<GameService>();

builder.Services.AddTransient<SqlConnection>(pc => new SqlConnection(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IGameService, GameDBService>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IGameService, GameService>();

//Scoped => Je garde l'instance pour tout la dur�e d'un appel http
// D�s qu'une nouvelle requ�te HTTP est produite => Service R�-instancier
//builder.Services.AddScoped<GameService>();

//Tansient => a chaque appel du service => nouvelle instance
//builder.Services.AddTransient<GameService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<SessionManager>();


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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
