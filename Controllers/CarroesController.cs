using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using patyy.Models;

namespace patyy.Controllers
{
    public class CarroesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public CarroesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: Carroes

        public async Task<IActionResult> Carrito()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<Carro>>("Carrito");
            if (carrito == null)
            {
                carrito = new List<Carro>();
            }

            foreach (var item in carrito)
            {
                item.producto = await _context.Productos
                    .FirstOrDefaultAsync(p => p.IdProducto == item.PedidosProductosIdProducto);
            }

            var totalCarrito = carrito.Sum(c => c.Total ?? 0);

            ViewBag.TotalCarrito = totalCarrito;

            return View(carrito); //devolvemos ala vista carrito 
        }
        [HttpPost]
        public IActionResult ActualizarCantidad(int productoId, string accion)
        {
            // Recuperamos la sesion del carrito 
            var carrito = HttpContext.Session.GetObjectFromJson<List<Carro>>("Carrito");
            if (carrito == null)
            {
                carrito = new List<Carro>();
            }

            // buscamos el producto ne el carrito 
            var producto = carrito.FirstOrDefault(c => c.PedidosProductosIdProducto == productoId);

            if (producto != null)
            {
                // actualizamos la cantidad enbase subamos o bajemos 
                if (accion == "aumentar")
                {
                    producto.Cantidad++;
                }
                else if (accion == "disminuir" && producto.Cantidad > 1)  // evitamos que la cantidad sea 0 pero si pasa deberia eliminarse nose como hacerla 
                {
                    producto.Cantidad--;
                }

                // esto actualiza el total de prodcuto 
                var precio = producto.Precio ?? 0;
                var cantidad = producto.Cantidad ?? 0;
                var descuento = producto.DescuentoAplicado ?? 0;
                var totalCalculado = (precio * cantidad) * (1 - (descuento / 100.0));

                // convierte el calculo de double  a int !
                producto.Total = (int)Math.Round(totalCalculado);
            }

            // guardamos el carrito actualizado en la sesion 
            HttpContext.Session.SetObjectAsJson("Carrito", carrito);

            // nos vamos a carrito
            return RedirectToAction("Carrito");
        }



        [HttpPost]
        public async Task<IActionResult> EliminarProducto(int productoId)
        {
            // Obtenemos el carro de la sesion si no hay no muestra 
            var carrito = HttpContext.Session.GetObjectFromJson<List<Carro>>("Carrito");

            // si no existe inica uno vacio 
            if (carrito == null)
            {
                carrito = new List<Carro>();
            }

            // buscamos el producto en el carrito mediante el id producto 
            var productoAEliminar = carrito.FirstOrDefault(c => c.PedidosProductosIdProducto == productoId);

            // si encontramos el producto lo eliminos 
            if (productoAEliminar != null)
            {
                carrito.Remove(productoAEliminar);

                // actualizamos la sesion con el carrito nuevo 
                HttpContext.Session.SetObjectAsJson("Carrito", carrito);
            }

            // ya te la sabes 
            return RedirectToAction(nameof(Carrito));
        }








        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.ToListAsync());
        }

        // GET: Carroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .FirstOrDefaultAsync(m => m.IdCarro == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarro,Cantidad,DescuentoAplicado,Precio,PedidosIdPedido,PedidosProductosIdProducto")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        // POST: Carroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarro,Cantidad,DescuentoAplicado,Precio,PedidosIdPedido,PedidosProductosIdProducto")] Carro carro)
        {
            if (id != carro.IdCarro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.IdCarro))
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
            return View(carro);
        }


        // GET: Carroes/Delete/5
        // GET: Carroes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var carro = await _context.Carros
                .FirstOrDefaultAsync(m => m.IdCarro == id);

            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros
                .FirstOrDefaultAsync(m => m.IdCarro == id);

            if (carro != null)
            {
                _context.Carros.Remove(carro);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Carrito));
        }


        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.IdCarro == id);
        }
    }
}
