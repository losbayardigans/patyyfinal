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
    public class EstadoHasPagoesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public EstadoHasPagoesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: EstadoHasPagoes
        public async Task<IActionResult> Index()
        {
            var proyectoFinalContext = _context.EstadoHasPagos.Include(e => e.EstadoIdEstadoNavigation).Include(e => e.Pago);
            return View(await proyectoFinalContext.ToListAsync());
        }

        // GET: EstadoHasPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHasPago = await _context.EstadoHasPagos
                .Include(e => e.EstadoIdEstadoNavigation)
                .Include(e => e.Pago)
                .FirstOrDefaultAsync(m => m.EstadoIdEstado == id);
            if (estadoHasPago == null)
            {
                return NotFound();
            }

            return View(estadoHasPago);
        }

        // GET: EstadoHasPagoes/Create
        public IActionResult Create()
        {
            ViewData["EstadoIdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado");
            ViewData["PagoIdPago"] = new SelectList(_context.Pagos, "IdPago", "IdPago");
            return View();
        }

        // POST: EstadoHasPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoIdEstado,PagoIdPago,PagoBoletaIdPago,PagoBoletaPedidosIdPedido,PagoBoletaPedidosProductosIdProducto,PagoBoletaPedidosClienteIdCliente,Observaciones,FechaCambioEstado")] EstadoHasPago estadoHasPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoHasPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoIdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", estadoHasPago.EstadoIdEstado);
            ViewData["PagoIdPago"] = new SelectList(_context.Pagos, "IdPago", "IdPago", estadoHasPago.PagoIdPago);
            return View(estadoHasPago);
        }

        // GET: EstadoHasPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHasPago = await _context.EstadoHasPagos.FindAsync(id);
            if (estadoHasPago == null)
            {
                return NotFound();
            }
            ViewData["EstadoIdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", estadoHasPago.EstadoIdEstado);
            ViewData["PagoIdPago"] = new SelectList(_context.Pagos, "IdPago", "IdPago", estadoHasPago.PagoIdPago);
            return View(estadoHasPago);
        }

        // POST: EstadoHasPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoIdEstado,PagoIdPago,PagoBoletaIdPago,PagoBoletaPedidosIdPedido,PagoBoletaPedidosProductosIdProducto,PagoBoletaPedidosClienteIdCliente,Observaciones,FechaCambioEstado")] EstadoHasPago estadoHasPago)
        {
            if (id != estadoHasPago.EstadoIdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoHasPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoHasPagoExists(estadoHasPago.EstadoIdEstado))
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
            ViewData["EstadoIdEstado"] = new SelectList(_context.Estados, "IdEstado", "IdEstado", estadoHasPago.EstadoIdEstado);
            ViewData["PagoIdPago"] = new SelectList(_context.Pagos, "IdPago", "IdPago", estadoHasPago.PagoIdPago);
            return View(estadoHasPago);
        }

        // GET: EstadoHasPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHasPago = await _context.EstadoHasPagos
                .Include(e => e.EstadoIdEstadoNavigation)
                .Include(e => e.Pago)
                .FirstOrDefaultAsync(m => m.EstadoIdEstado == id);
            if (estadoHasPago == null)
            {
                return NotFound();
            }

            return View(estadoHasPago);
        }

        // POST: EstadoHasPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoHasPago = await _context.EstadoHasPagos.FindAsync(id);
            if (estadoHasPago != null)
            {
                _context.EstadoHasPagos.Remove(estadoHasPago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoHasPagoExists(int id)
        {
            return _context.EstadoHasPagos.Any(e => e.EstadoIdEstado == id);
        }
    }
}
