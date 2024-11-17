using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using patyy.Models;
using System.Diagnostics;
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
        var carrito = HttpContext.Session.GetObjectFromJson<List<Carro>>("Carrito");
        if (carrito == null || !carrito.Any())
        {
            return RedirectToAction("Carrito", "Carroes");
        }

        var cliente = User.Identity.IsAuthenticated
            ? _context.Clientes.FirstOrDefault(c => c.Correo == User.Identity.Name)
            : null;

        var checkoutViewModel = new CheckoutViewModel
        {//estos son auntenticadores 
            ClienteIdCliente = User.Identity.IsAuthenticated
           ? _context.Clientes.FirstOrDefault(c => c.Correo == User.Identity.Name)?.IdCliente
           : null,
            Nombre = User.Identity.IsAuthenticated
           ? _context.Clientes.FirstOrDefault(c => c.Nombre == User.Identity.Name)?.Nombre
           : null,
            Direccion = User.Identity.IsAuthenticated
           ? _context.Clientes.FirstOrDefault(c => c.Direccion == User.Identity.Name)?.Direccion
           : null,
            Correo = User.Identity.IsAuthenticated ? User.Identity.Name : null,
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


    [HttpPost]
    public async Task<IActionResult> ConfirmarCompra([FromForm] CheckoutViewModel model)
    {   //esto basicamente es para verificar si el formulario esta siendo tomado lo cual si lo hace pero el problema es el id :C
        Console.WriteLine("Recibido el formulario:");
        Console.WriteLine($"Nombre: {model.Nombre}, Correo: {model.Correo}, MetodoPago: {model.MetodoPago}");
        Console.WriteLine("Formulario recibido:");
        Console.WriteLine($"Nombre: {model.Nombre}");
        Console.WriteLine($"Dirección: {model.Direccion}");
        Console.WriteLine($"Correo: {model.Correo}");
        Console.WriteLine($"Método de pago: {model.MetodoPago}");
        Console.WriteLine($"Es invitado: {model.EsInvitado}");
        Console.WriteLine($"Cliente ID: {model.ClienteIdCliente}");
        Console.WriteLine($"Total: {model.Total}");
        Console.WriteLine($"Productos: {model.Productos?.Count} productos");

        if (ModelState.IsValid)
        {
            int clienteId; // Ddeclaramos el clienteid (de IdCliente)

            // Caso de cliente invitado
            if (model.EsInvitado)
            {
                //verifica las credenciales existentes
                var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Correo == model.Correo);
                if (clienteExistente != null)
                {
                    //si encuentra un id de cliente usamos ese 
                    clienteId = clienteExistente.IdCliente;
                }
                else
                {
                    // Crear un nuevo cliente
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
                // Si el cliente no es invitado, usamos el ID del modelo
                clienteId = model.ClienteIdCliente ?? 0;
                var clienteRegistrado = _context.Clientes.FirstOrDefault(c => c.IdCliente == clienteId);

                if (clienteRegistrado == null)
                {
                    // Si no se encuentra el cliente registrado
                    return BadRequest("Cliente no encontrado.");
                }
            }

            if (clienteId == 0)
            {
                return BadRequest("No se pudo asignar un cliente válido.");
            }

            // esto basicamente crea el pedido
            var pedido = new Pedido
            {
                ClienteIdCliente = clienteId,
                MetodoPago = model.MetodoPago,
                Total = model.Total,
                EstadoPedido = "Pendiente",
                FechaPedido = DateTime.Now
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            // Agregas los productos al pedido
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


    // esto esta en alpha deberia ser complemento de confirmacion pedido pero ahi esta xd
    /*
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

        // Crear un ViewModel para la confirmación
        var confirmacionViewModel = new CheckoutViewModel.ConfirmacionViewModel
        {
            PedidoId = pedido.IdPedido,
            Total = pedido.Total.GetValueOrDefault(),
            Cliente = pedido.ClienteIdClienteNavigation,
            Productos = pedido.PedidosHasProductos.Select(pp => new CheckoutViewModel.ProductoCarritoViewModel
            {
                IdProducto = pp.Producto.IdProducto,
                Nombre = pp.Producto.Nombre,
                Cantidad = pp.Cantidad ?? 0,
                Precio = pp.Precio.GetValueOrDefault()
            }).ToList()
        };

        // Devolver la vista de confirmación con los detalles del pedido
        return View(confirmacionViewModel);
    }
    */
}
