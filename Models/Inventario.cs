using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Inventario
{
    public int IdCategoria { get; set; }

    public string? CantidadDisponible { get; set; }

    public string? NombreProducto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
