using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Carro
{
    public int IdCarro { get; set; }

    public string? Cantidad { get; set; }

    public string? DescuentoAplicado { get; set; }

    public string? Precio { get; set; }

    public int PedidosIdPedido { get; set; }

    public int PedidosProductosIdProducto { get; set; }
}
