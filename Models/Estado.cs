using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
