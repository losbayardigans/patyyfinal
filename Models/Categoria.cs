using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public string? NombreCategoria { get; set; }

    public string? CantidadCategorias { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
