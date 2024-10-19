using Microsoft.EntityFrameworkCore;
using patyy.Models;

var builder = WebApplication.CreateBuilder(args);

// servicios 
builder.Services.AddControllersWithViews();



// base de datos 
builder.Services.AddDbContext<ProyectoFinalContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Connection"),
        ServerVersion.Parse("10.4.25-mariadb")
    ));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); //esto mide la sesion del usuario en este caso 30 min esta perfecto 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();


// Configurar el pipeline de la aplicación.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTP Strict Transport Security.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// **Middleware de sesión: Debe ir antes de la autorización.**
app.UseSession();

app.UseAuthorization();

// Rutas de los controladores.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
