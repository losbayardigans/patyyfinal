using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public string? NombreCategoria { get; set; }

    public int? CantidadCategorias { get; set; }

    public string? EstadoCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
