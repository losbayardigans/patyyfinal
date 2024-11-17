using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace patyy.Models
{//este modelo almacena datos temp y reune varios para despues guardar los datos directamente ne cada tabla correspondiente 
    public class CheckoutViewModel
    {
        // esto es la info del cliente
        [BindProperty]
        public int? ClienteIdCliente { get; set; }

        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Correo { get; set; }
        public string? MetodoPago { get; set; }
        public bool EsInvitado { get; set; } = false;

        // esto es la lista de productos
        public List<ProductoCarritoViewModel> Productos { get; set; } = new List<ProductoCarritoViewModel>();

        // es el total del producto
        public int Total { get; set; }

        // esto es el codigo de descuento pero es referencia
        public string? CodigoDescuento { get; set; }
        //esto es de la tabla productos y carro
        public class ProductoCarritoViewModel
        {
            public int IdProducto { get; set; }
            public string? Nombre { get; set; }
            public int Cantidad { get; set; }
            public int Precio { get; set; }
            public int Subtotal => Cantidad * Precio;
        }
        //esto es pa la confirmacion del pedido
        public class ConfirmacionViewModel
        {
            public int PedidoId { get; set; }
            public List<ProductoCarritoViewModel> Productos { get; set; } = new List<ProductoCarritoViewModel>();
            public int Total { get; set; }
            public Cliente Cliente { get; set; } = new Cliente();
            public string? MetodoPago { get; set; }
        }
    }
}
