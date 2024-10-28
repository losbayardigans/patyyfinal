using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using patyy.Models;

namespace patyy.Controllers
{
    public class PedidosHasProductoesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public PedidosHasProductoesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: PedidosHasProductoes
        public async Task<IActionResult> Index()
        {
            var proyectoFinalContext = _context.PedidosHasProductos.Include(p => p.Pedido).Include(p => p.Producto);
            return View(await proyectoFinalContext.ToListAsync());
        }

        // GET: PedidosHasProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidosHasProducto = await _context.PedidosHasProductos
                .Include(p => p.Pedido)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.PedidosIdPedido == id);
            if (pedidosHasProducto == null)
            {
                return NotFound();
            }

            return View(pedidosHasProducto);
        }

        // GET: PedidosHasProductoes/Create
        public IActionResult Create()
        {
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido");
            ViewData["ProductosIdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: PedidosHasProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidosIdPedido,PedidosProductosIdProducto,PedidosClienteIdCliente,ProductosIdProducto,ProductosCategoriasIdCategoria,ProductosInventarioIdCategoria,ProductosProveedorIdProveedor,Cantidad,Precio,PedidosHasProductoscol")] PedidosHasProducto pedidosHasProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidosHasProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", pedidosHasProducto.PedidosIdPedido);
            ViewData["ProductosIdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", pedidosHasProducto.ProductosIdProducto);
            return View(pedidosHasProducto);
        }

        // GET: PedidosHasProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidosHasProducto = await _context.PedidosHasProductos.FindAsync(id);
            if (pedidosHasProducto == null)
            {
                return NotFound();
            }
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", pedidosHasProducto.PedidosIdPedido);
            ViewData["ProductosIdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", pedidosHasProducto.ProductosIdProducto);
            return View(pedidosHasProducto);
        }

        // POST: PedidosHasProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidosIdPedido,PedidosProductosIdProducto,PedidosClienteIdCliente,ProductosIdProducto,ProductosCategoriasIdCategoria,ProductosInventarioIdCategoria,ProductosProveedorIdProveedor,Cantidad,Precio,PedidosHasProductoscol")] PedidosHasProducto pedidosHasProducto)
        {
            if (id != pedidosHasProducto.PedidosIdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidosHasProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidosHasProductoExists(pedidosHasProducto.PedidosIdPedido))
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
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", pedidosHasProducto.PedidosIdPedido);
            ViewData["ProductosIdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", pedidosHasProducto.ProductosIdProducto);
            return View(pedidosHasProducto);
        }

        // GET: PedidosHasProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidosHasProducto = await _context.PedidosHasProductos
                .Include(p => p.Pedido)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.PedidosIdPedido == id);
            if (pedidosHasProducto == null)
            {
                return NotFound();
            }

            return View(pedidosHasProducto);
        }

        // POST: PedidosHasProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidosHasProducto = await _context.PedidosHasProductos.FindAsync(id);
            if (pedidosHasProducto != null)
            {
                _context.PedidosHasProductos.Remove(pedidosHasProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidosHasProductoExists(int id)
        {
            return _context.PedidosHasProductos.Any(e => e.PedidosIdPedido == id);
        }
    }
}
