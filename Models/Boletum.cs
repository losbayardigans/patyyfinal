using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Boletum
{
    public int IdPago { get; set; }

    public string? Monto { get; set; }

    public string? MetodoPago { get; set; }

    public int PedidosIdPedido { get; set; }

    public int PedidosProductosIdProducto { get; set; }

    public int PedidosClienteIdCliente { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Pedido Pedido { get; set; } = null!;
}
