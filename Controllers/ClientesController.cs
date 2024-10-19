using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using patyy.Models;

namespace patyy.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public ClientesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: Clientes
        
        public IActionResult Login()
        {
            return View();
        }

        // POST: Clientes/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        //configuramos el login para que pueda iniciar sesion tomando solo correo y contraseña 
        public async Task<IActionResult> Login(string correo, string contraseña)
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                ModelState.AddModelError(string.Empty, "esto es obligatorio pe mi kong .");
                return View();
            }

            // buscamos al cliente por su correo y contraseña solo al logearse , al registrarse se le pedira su nombre y apellido 
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Correo == correo && c.Contraseña == contraseña);

            if (cliente == null)
            {
                ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
                return View();
            }

            // Guardar datos en sesión para el cliente autenticado
            HttpContext.Session.SetInt32("IdCliente", cliente.IdCliente);
            HttpContext.Session.SetString("NombreCliente", cliente.Nombre ?? "Usuario");

            return RedirectToAction("Index", "Home");
        }

        // GET: Clientes/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpiar la sesión
            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Cliente model)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Correo = model.Correo,
                    Contraseña = model.Contraseña, //falta hasearla tocara mover el codigo completo gaaa
                    FechaRegistro = DateTime.Now
                };
                //aca agregagamos y guardamos en la bs tomando el idcliente 
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                // Guardar ID del cliente en sesión
                HttpContext.Session.SetInt32("IdCliente", cliente.IdCliente);

                return RedirectToAction( "Login");
            }
            return View(model);
        }






        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Nombre,Apellido,Correo,Direccion,Telefono,Clientecol")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Nombre,Apellido,Correo,Direccion,Telefono,Clientecol")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
