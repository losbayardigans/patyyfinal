using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? CantidadProductos { get; set; }

    public int? Precio { get; set; }

    public int CategoriasIdCategoria { get; set; }

    public int InventarioIdCategoria { get; set; }

    public int ProveedorIdProveedor { get; set; }

    public string? EstadoProducto { get; set; }

    public virtual Categoria CategoriasIdCategoriaNavigation { get; set; } = null!;

    public virtual Inventario InventarioIdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<PedidosHasProducto> PedidosHasProductos { get; set; } = new List<PedidosHasProducto>();

    public virtual Proveedor ProveedorIdProveedorNavigation { get; set; } = null!;
}
