using Microsoft.AspNetCore.Mvc;
using patyy.Models;

public class CheckoutViewModel
{
    // Información del cliente
    [BindProperty]
    public int? ClienteIdCliente { get; set; }

    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Correo { get; set; }
    public string? MetodoPago { get; set; }
    public bool EsInvitado { get; set; } = false;

    // Propiedades adicionales para la dirección
    public string? Ciudad { get; set; } // Añadida propiedad para la ciudad
    public string? Region { get; set; } // Añadida propiedad para la región
    public string? CodigoPostal { get; set; } // Añadida propiedad para el código postal

    public string? pais { get; set; }
    // Lista de productos
    public List<ProductoCarritoViewModel> Productos { get; set; } = new List<ProductoCarritoViewModel>();

    // Campo privado para almacenar el total
    private int _total;

    // Total de la compra
    public int Total
    {
        get => _total;
        set => _total = value;
    }

    // Código de descuento
    public string? CodigoDescuento { get; set; }

    // Submodelo para productos del carrito
    public class ProductoCarritoViewModel
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        // Cálculo del subtotal por producto
        public int Subtotal => Cantidad * Precio;
    }

    // Modelo de confirmación de pedido
    public class ConfirmacionViewModel
    {
        public int PedidoId { get; set; }
        public List<ProductoCarritoViewModel> Productos { get; set; } = new List<ProductoCarritoViewModel>();
        public int Total { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();
        public string? MetodoPago { get; set; }
    }
}
