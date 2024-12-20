﻿using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int? Total { get; set; }

    public string? MetodoPago { get; set; }

    public string? EstadoPedido { get; set; }

    public int ProductosIdProducto { get; set; }

    public int?ClienteIdCliente { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Region {  get; set; }

    public string? Ciudad {  get; set; }

    public string? notas {  get; set; }

    public string? pais {  get; set; }

    public virtual ICollection<Boletum> Boleta { get; set; } = new List<Boletum>();

    public virtual Cliente ClienteIdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual ICollection<EstadoHasPedido> EstadoHasPedidos { get; set; } = new List<EstadoHasPedido>();

    public virtual ICollection<PedidosHasProducto> PedidosHasProductos { get; set; } = new List<PedidosHasProducto>();
   
}
