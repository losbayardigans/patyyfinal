using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using patyy.Models;

namespace patyy.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public ProductoesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // Acción para mostrar el botón de categorías
        public async Task<IActionResult> boton()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return Json(categorias);
        }


        public async Task<IActionResult> Index_prod()
        {
            var productos = _context.Productos
                .Include(p => p.CategoriasIdCategoriaNavigation)
                .Include(p => p.InventarioIdInventarioNavigation)
                .Include(p => p.ProveedorIdProveedorNavigation);
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Index()
        {
            var productos = _context.Productos
                 .Include(p => p.CategoriasIdCategoriaNavigation)
                 .Include(p => p.InventarioIdInventarioNavigation)
                 .Include(p => p.ProveedorIdProveedorNavigation);
            return View(await productos.ToListAsync());
        }


        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.CategoriasIdCategoriaNavigation)
                .Include(p => p.InventarioIdInventarioNavigation)
                .Include(p => p.ProveedorIdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            {
                ViewData["CategoriasIdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria");
                ViewData["InventarioIdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario");
                ViewData["ProveedorIdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor");
                return View();
            }
        }

        // POST: Productoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion,CantidadProductos,CategoriasIdCategoria,InventarioIdCategoria,ProveedorIdProveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Manejar excepciones (como violaciones de clave foránea)
                    ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                }
            }

            // Si llegamos aquí, algo falló; vuelve a mostrar el formulario
            ViewData["CategoriasIdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "NombreCategoria", producto.CategoriasIdCategoria);
            ViewData["InventarioIdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", producto.InventarioIdInventario);
            ViewData["ProveedorIdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", producto.ProveedorIdProveedor);
            return View(producto);
        }





        // Método para obtener la URL de la imagen basada en la descripción del produc
        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            ViewData["CategoriasIdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", producto.CategoriasIdCategoria);
            ViewData["InventarioIdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", producto.InventarioIdInventario);
            ViewData["ProveedorIdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", producto.ProveedorIdProveedor);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,Descripcion,CantidadProductos,CategoriasIdCategoria,InventarioIdCategoria,ProveedorIdProveedor")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
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

            ViewData["CategoriasIdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", producto.CategoriasIdCategoria);
            ViewData["InventarioIdInventario"] = new SelectList(_context.Inventarios, "IdInventario", "IdInventario", producto.InventarioIdInventario);
            ViewData["ProveedorIdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", producto.ProveedorIdProveedor);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.CategoriasIdCategoriaNavigation)
                .Include(p => p.InventarioIdInventarioNavigation)
                .Include(p => p.ProveedorIdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}