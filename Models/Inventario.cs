using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int? CantidadDisponible { get; set; }

    public string? NombreProducto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
