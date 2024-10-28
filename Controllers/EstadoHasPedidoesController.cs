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
    public class EstadoHasPedidoesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public EstadoHasPedidoesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: EstadoHasPedidoes
        public async Task<IActionResult> Index()
        {
            var proyectoFinalContext = _context.EstadoHasPedidos.Include(e => e.EstadoIdEstadoNavigation).Include(e => e.Pedido);
            return View(await proyectoFinalContext.ToListAsync());
        }

        // GET: EstadoHasPedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHasPedido = await _context.EstadoHasPedidos
                .Include(e => e.EstadoIdEstadoNavigation)
                .Include(e => e.Pedido)
                .FirstOrDefaultAsync(m => m.EstadoIdEstado == id);
            if (estadoHasPedido == null)
            {
                return NotFound();
            }

            return View(estadoHasPedido);
        }

        // GET: EstadoHasPedidoes/Create
        public IActionResult Create()
        {
            ViewData["EstadoIdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado");
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido");
            return View();
        }

        // POST: EstadoHasPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoIdEstado,PedidosIdPedido,PedidosProductosIdProducto,PedidosClienteIdCliente,FechaCambioEstado,Observaciones")] EstadoHasPedido estadoHasPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoHasPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoIdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", estadoHasPedido.EstadoIdEstado);
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", estadoHasPedido.PedidosIdPedido);
            return View(estadoHasPedido);
        }

        // GET: EstadoHasPedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHasPedido = await _context.EstadoHasPedidos.FindAsync(id);
            if (estadoHasPedido == null)
            {
                return NotFound();
            }
            ViewData["EstadoIdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", estadoHasPedido.EstadoIdEstado);
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", estadoHasPedido.PedidosIdPedido);
            return View(estadoHasPedido);
        }

        // POST: EstadoHasPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoIdEstado,PedidosIdPedido,PedidosProductosIdProducto,PedidosClienteIdCliente,FechaCambioEstado,Observaciones")] EstadoHasPedido estadoHasPedido)
        {
            if (id != estadoHasPedido.EstadoIdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoHasPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoHasPedidoExists(estadoHasPedido.EstadoIdEstado))
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
            ViewData["EstadoIdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", estadoHasPedido.EstadoIdEstado);
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", estadoHasPedido.PedidosIdPedido);
            return View(estadoHasPedido);
        }

        // GET: EstadoHasPedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHasPedido = await _context.EstadoHasPedidos
                .Include(e => e.EstadoIdEstadoNavigation)
                .Include(e => e.Pedido)
                .FirstOrDefaultAsync(m => m.EstadoIdEstado == id);
            if (estadoHasPedido == null)
            {
                return NotFound();
            }

            return View(estadoHasPedido);
        }

        // POST: EstadoHasPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoHasPedido = await _context.EstadoHasPedidos.FindAsync(id);
            if (estadoHasPedido != null)
            {
                _context.EstadoHasPedidos.Remove(estadoHasPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoHasPedidoExists(int id)
        {
            return _context.EstadoHasPedidos.Any(e => e.EstadoIdEstado == id);
        }
    }
}
