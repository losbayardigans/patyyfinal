using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Carro
{
    public int IdCarro { get; set; }

    public int? Cantidad { get; set; }

    public int? DescuentoAplicado { get; set; }

    public int? Precio { get; set; }

    public int PedidosIdPedido { get; set; }

    public int PedidosProductosIdProducto { get; set; }

    public int Total {  get; set; }
}
