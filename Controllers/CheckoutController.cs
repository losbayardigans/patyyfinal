using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using patyy.Models;
using System.Linq;
using System.Threading.Tasks;

public class CheckoutController : Controller
{
    private readonly ProyectoFinalContext _context;

    public CheckoutController(ProyectoFinalContext context)
    {
        _context = context;
    }

    // GET: Checkout - Página de Checkout
    public IActionResult Index()
    {
        // Obtener el carrito desde la sesión
        var carrito = HttpContext.Session.GetObjectFromJson<List<Carro>>("Carrito");
        if (carrito == null || !carrito.Any())
        {
            return RedirectToAction("Carrito", "Carroes");
        }

        // Obtener el cliente autenticado
        var cliente = User.Identity.IsAuthenticated
            ? _context.Clientes.FirstOrDefault(c => c.Correo == User.Identity.Name)
            : null;

        // Obtener el último pedido pendiente del cliente
        var pedido = cliente != null
            ? _context.Pedidos.FirstOrDefault(p => p.ClienteIdCliente == cliente.IdCliente && p.EstadoPedido == "Pendiente")
            : null;

        // Crear el modelo de Checkout
        var checkoutViewModel = new CheckoutViewModel
        {
            ClienteIdCliente = cliente?.IdCliente,
            Nombre = cliente?.Nombre,
            Direccion = cliente?.Direccion,
            Correo = cliente?.Correo ?? User.Identity.Name,
            // Obtener la información de Ciudad, Región y Código Postal desde el último pedido
            Ciudad = pedido?.Ciudad,
            Region = pedido?.Region,
            CodigoPostal = pedido?.CodigoPostal,
            pais = pedido?.pais,
            Productos = carrito.Select(item => new CheckoutViewModel.ProductoCarritoViewModel
            {
                IdProducto = item.PedidosProductosIdProducto,
                Nombre = _context.Productos.FirstOrDefault(p => p.IdProducto == item.PedidosProductosIdProducto)?.Nombre,
                Cantidad = (int)item.Cantidad,
                Precio = item.Precio ?? 0
            }).ToList(),
            Total = carrito.Sum(c => c.Precio.GetValueOrDefault(0) * c.Cantidad.GetValueOrDefault(0))
        };

        return View("~/Views/Pedidoes/Checkout.cshtml", checkoutViewModel);
    }

    // POST: Confirmar compra
    [HttpPost]
    public async Task<IActionResult> ConfirmarCompra([FromForm] CheckoutViewModel model)
    {
        // Mostrar datos del formulario en la consola para depuración
        Console.WriteLine("Formulario recibido:");
        Console.WriteLine($"Nombre: {model.Nombre}");
        Console.WriteLine($"Dirección: {model.Direccion}");
        Console.WriteLine($"Correo: {model.Correo}");
        Console.WriteLine($"Método de pago: {model.MetodoPago}");
        Console.WriteLine($"Es invitado: {model.EsInvitado}");
        Console.WriteLine($"Cliente ID: {model.ClienteIdCliente}");
        Console.WriteLine($"Ciudad: {model.Ciudad}");
        Console.WriteLine($"Región: {model.Region}");
        Console.WriteLine($"Código Postal: {model.CodigoPostal}");
        Console.WriteLine($"Total: {model.Total}");
        Console.WriteLine($"Productos: {model.Productos?.Count} productos");

        if (ModelState.IsValid)
        {
            int clienteId;

            // Si el cliente es invitado
            if (model.EsInvitado)
            {
                var clienteExistente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Correo == model.Correo);

                if (clienteExistente != null)
                {
                    clienteId = clienteExistente.IdCliente;
                }
                else
                {
                    var clienteInvitado = new Cliente
                    {
                        Nombre = model.Nombre,
                        Direccion = model.Direccion,
                        Correo = model.Correo
                    };
                    _context.Clientes.Add(clienteInvitado);
                    await _context.SaveChangesAsync();
                    clienteId = clienteInvitado.IdCliente;
                }
            }
            else
            {
                // Si el cliente está registrado, buscamos el ID
                clienteId = model.ClienteIdCliente ?? 0;
                var clienteRegistrado = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.IdCliente == clienteId);

                if (clienteRegistrado == null)
                {
                    return BadRequest("Cliente no encontrado.");
                }
            }

            if (clienteId == 0)
            {
                return BadRequest("No se pudo asignar un cliente válido.");
            }

            // Crear el pedido
            var pedido = new Pedido
            {
                ClienteIdCliente = clienteId,
                MetodoPago = model.MetodoPago,
                Total = model.Total,
                EstadoPedido = "Pendiente",
                FechaPedido = DateTime.Now,
                Ciudad = model.Ciudad,    // Se asignan los valores de la ciudad, región y código postal
                Region = model.Region,
                CodigoPostal = model.CodigoPostal
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            // Agregar productos al pedido
            foreach (var item in model.Productos)
            {
                var pedidoProducto = new PedidosHasProducto
                {
                    PedidosIdPedido = pedido.IdPedido,
                    ProductosIdProducto = item.IdProducto,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio
                };
                _context.PedidosHasProductos.Add(pedidoProducto);
            }

            await _context.SaveChangesAsync();

            // Limpiar el carrito de la sesión
            HttpContext.Session.Remove("Carrito");

            // Redirigir a la página de confirmación
            return RedirectToAction("Confirmacion", new { id = pedido.IdPedido });
        }

        // Si el modelo no es válido, regresar al formulario de checkout
        return View("~/Views/Pedidoes/Checkout.cshtml", model);
    }

    // GET: Confirmación del pedido
    public IActionResult Confirmacion(int id)
    {
        var pedido = _context.Pedidos
                             .Include(p => p.ClienteIdClienteNavigation)
                             .Include(p => p.PedidosHasProductos)
                                 .ThenInclude(pp => pp.Producto)
                             .FirstOrDefault(p => p.IdPedido == id);

        if (pedido == null)
        {
            return NotFound();
        }

        var confirmacionViewModel = new CheckoutViewModel.ConfirmacionViewModel
        {
            PedidoId = pedido.IdPedido,
            Total = pedido.Total.GetValueOrDefault(),
            Cliente = pedido.ClienteIdClienteNavigation,
            MetodoPago = pedido.MetodoPago,
            Productos = pedido.PedidosHasProductos.Select(pp => new CheckoutViewModel.ProductoCarritoViewModel
            {
                IdProducto = pp.Producto.IdProducto,
                Nombre = pp.Producto.Nombre,
                Cantidad = pp.Cantidad ?? 0,
                Precio = pp.Precio.GetValueOrDefault()
            }).ToList()
        };

        return View(confirmacionViewModel);
    }
}
