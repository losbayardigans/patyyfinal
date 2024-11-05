using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class PedidosHasProducto
{
    public int PedidosIdPedido { get; set; }

    public int PedidosProductosIdProducto { get; set; }

    public int PedidosClienteIdCliente { get; set; }

    public int ProductosIdProducto { get; set; }

    public int ProductosCategoriasIdCategoria { get; set; }

    public int ProductosInventarioIdInventario { get; set; }

    public int ProductosProveedorIdProveedor { get; set; }

    public int? Cantidad { get; set; }

    public int? Precio { get; set; }

    public string? PedidosHasProductoscol { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
