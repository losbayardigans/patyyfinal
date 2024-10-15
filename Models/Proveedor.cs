using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Contacto { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaProveedor { get; set; }

    public string? EstadoProveedor { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
