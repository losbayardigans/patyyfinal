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
    public class BoletumsController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public BoletumsController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: Boletums
        public async Task<IActionResult> Index()
        {
            var proyectoFinalContext = _context.Boleta.Include(b => b.Pedido);
            return View(await proyectoFinalContext.ToListAsync());
        }

        // GET: Boletums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletum = await _context.Boleta
                .Include(b => b.Pedido)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (boletum == null)
            {
                return NotFound();
            }

            return View(boletum);
        }

        // GET: Boletums/Create
        public IActionResult Create()
        {
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido");
            return View();
        }

        // POST: Boletums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPago,Monto,MetodoPago,PedidosIdPedido,PedidosProductosIdProducto,PedidosClienteIdCliente")] Boletum boletum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boletum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", boletum.PedidosIdPedido);
            return View(boletum);
        }

        // GET: Boletums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletum = await _context.Boleta.FindAsync(id);
            if (boletum == null)
            {
                return NotFound();
            }
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", boletum.PedidosIdPedido);
            return View(boletum);
        }

        // POST: Boletums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPago,Monto,MetodoPago,PedidosIdPedido,PedidosProductosIdProducto,PedidosClienteIdCliente")] Boletum boletum)
        {
            if (id != boletum.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boletum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletumExists(boletum.IdPago))
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
            ViewData["PedidosIdPedido"] = new SelectList(_context.Pedidos, "IdPedido", "IdPedido", boletum.PedidosIdPedido);
            return View(boletum);
        }

        // GET: Boletums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boletum = await _context.Boleta
                .Include(b => b.Pedido)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (boletum == null)
            {
                return NotFound();
            }

            return View(boletum);
        }

        // POST: Boletums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boletum = await _context.Boleta.FindAsync(id);
            if (boletum != null)
            {
                _context.Boleta.Remove(boletum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletumExists(int id)
        {
            return _context.Boleta.Any(e => e.IdPago == id);
        }
    }
}
