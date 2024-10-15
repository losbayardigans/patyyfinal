using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class EstadoHasPedido
{
    public int EstadoIdEstado { get; set; }

    public int PedidosIdPedido { get; set; }

    public int PedidosProductosIdProducto { get; set; }

    public int PedidosClienteIdCliente { get; set; }

    public DateTime? FechaCambioEstado { get; set; }

    public string? Observaciones { get; set; }

    public virtual Estado EstadoIdEstadoNavigation { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;
}
