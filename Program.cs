using Microsoft.EntityFrameworkCore;
using patyy.Models;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllersWithViews();

// Base de datos
builder.Services.AddDbContext<ProyectoFinalContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Connection"),
        ServerVersion.Parse("10.4.25-mariadb")
    ));

// Sesi�n
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Carrito.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Duraci�n de la sesi�n
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configurar el pipeline de la aplicaci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Seguridad de transporte HTTP
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Middleware de sesi�n: Debe ir antes de la autorizaci�n.
app.UseSession();

app.UseAuthorization();

// Rutas de los controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
