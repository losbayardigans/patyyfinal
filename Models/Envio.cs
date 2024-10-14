using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Envio
{
    public int IdEnvios { get; set; }

    public string? DireccionEnvio { get; set; }

    public string? FechaEnvio { get; set; }

    public string? FechaEntregaEstimada { get; set; }

    public string? EstadoEnvio { get; set; }

    public string? EmpresaEnvio { get; set; }

    public int PedidosIdPedido { get; set; }

    public int PedidosProductosIdProducto { get; set; }

    public int PedidosClienteIdCliente { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;
}
