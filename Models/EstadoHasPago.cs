using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class EstadoHasPago
{
    public int EstadoIdEstado { get; set; }

    public int PagoIdPago { get; set; }

    public int PagoBoletaIdPago { get; set; }

    public int PagoBoletaPedidosIdPedido { get; set; }

    public int PagoBoletaPedidosProductosIdProducto { get; set; }

    public int PagoBoletaPedidosClienteIdCliente { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaCambioEstado { get; set; }

    public virtual Estado EstadoIdEstadoNavigation { get; set; } = null!;

    public virtual Pago Pago { get; set; } = null!;
}
