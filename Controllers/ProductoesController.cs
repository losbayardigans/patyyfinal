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
        [HttpPost]
        public async Task<IActionResult> AgregarAlCarrito(int productoId)
        {
            var producto = await _context.Productos
                .Where(p => p.IdProducto == productoId)
                .FirstOrDefaultAsync();

            if (producto == null)
            {
                return NotFound();
            }

            var carrito = HttpContext.Session.GetObjectFromJson<List<Carro>>("Carrito");
            if (carrito == null)
            {
                carrito = new List<Carro>();
            }

            var itemCarrito = carrito.FirstOrDefault(c => c.PedidosProductosIdProducto == productoId);
            if (itemCarrito == null)
            {
                carrito.Add(new Carro
                {
                    PedidosProductosIdProducto = productoId,
                    Cantidad = 1,
                    Precio = producto.Precio
                });
            }
            else
            {
                itemCarrito.Cantidad++;
            }

            // Llamamos al método para actualizar el total de cada item en el carrito
            foreach (var item in carrito)
            {
                item.ActualizarTotal();  //deberia actualizar pero algo pasa :C
            }

            HttpContext.Session.SetObjectAsJson("Carrito", carrito);

            return RedirectToAction("Carrito", "Carroes");  
        }




        public async Task<IActionResult> Index_prod()
        {
            var productos = await _context.Productos
                 .Include(p => p.CategoriasIdCategoriaNavigation)
                .Include(p => p.InventarioIdInventarioNavigation)
                .Include(p => p.ProveedorIdProveedorNavigation)
                .ToListAsync();

            var categorias = await _context.Categorias.ToListAsync();
            //almacenamos en un data las categorias basicamente para hacer funcionar el todos xd
            ViewData["Categorias"] = categorias;

            return View(productos);
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
        public async Task<IActionResult> Create([Bind("Descripcion,CantidadProductos,CategoriasIdCategoria,InventarioIdInventario,ProveedorIdProveedor")] Producto producto)
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
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,Descripcion,CantidadProductos,CategoriasIdCategoria,InventarioIdInventario,ProveedorIdProveedor")] Producto producto)
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

        // POST: Carroes/Delete/5
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