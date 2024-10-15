using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Descripcion { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<EstadoHasPago> EstadoHasPagos { get; set; } = new List<EstadoHasPago>();

    public virtual ICollection<EstadoHasPedido> EstadoHasPedidos { get; set; } = new List<EstadoHasPedido>();
}
