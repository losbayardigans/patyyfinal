using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? Monto { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? EstadoPago { get; set; }

    public int BoletaIdPago { get; set; }

    public int BoletaPedidosIdPedido { get; set; }

    public int BoletaPedidosProductosIdProducto { get; set; }

    public int BoletaPedidosClienteIdCliente { get; set; }

    public virtual Boletum Boletum { get; set; } = null!;

    public virtual ICollection<EstadoHasPago> EstadoHasPagos { get; set; } = new List<EstadoHasPago>();
}
