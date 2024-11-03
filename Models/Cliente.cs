﻿using System;
using System.Collections.Generic;

namespace patyy.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? EstadoCliente { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
