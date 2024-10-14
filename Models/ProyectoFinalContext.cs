using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace patyy.Models;

public partial class ProyectoFinalContext : DbContext
{
    public ProyectoFinalContext()
    {
    }

    public ProyectoFinalContext(DbContextOptions<ProyectoFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boletum> Boleta { get; set; }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=proyecto_final;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Boletum>(entity =>
        {
            entity.HasKey(e => new { e.IdPago, e.PedidosIdPedido, e.PedidosProductosIdProducto, e.PedidosClienteIdCliente })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("boleta");

            entity.HasIndex(e => new { e.PedidosIdPedido, e.PedidosProductosIdProducto, e.PedidosClienteIdCliente }, "fk_boleta_pedidos1_idx");

            entity.Property(e => e.IdPago)
                .HasColumnType("int(11)")
                .HasColumnName("id_pago");
            entity.Property(e => e.PedidosIdPedido)
                .HasColumnType("int(11)")
                .HasColumnName("pedidos_id_pedido");
            entity.Property(e => e.PedidosProductosIdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("pedidos_productos_id_producto");
            entity.Property(e => e.PedidosClienteIdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("pedidos_cliente_id_cliente");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(45)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasMaxLength(45)
                .HasColumnName("monto");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Boleta)
                .HasForeignKey(d => new { d.PedidosIdPedido, d.PedidosProductosIdProducto, d.PedidosClienteIdCliente })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_boleta_pedidos1");
        });

        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasKey(e => new { e.IdCarro, e.PedidosIdPedido, e.PedidosProductosIdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("carro");

            entity.HasIndex(e => new { e.PedidosIdPedido, e.PedidosProductosIdProducto }, "fk_carro_pedidos1_idx");

            entity.Property(e => e.IdCarro)
                .HasColumnType("int(11)")
                .HasColumnName("id_carro");
            entity.Property(e => e.PedidosIdPedido)
                .HasColumnType("int(11)")
                .HasColumnName("pedidos_id_pedido");
            entity.Property(e => e.PedidosProductosIdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("pedidos_productos_id_producto");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(45)
                .HasColumnName("cantidad");
            entity.Property(e => e.DescuentoAplicado)
                .HasMaxLength(45)
                .HasColumnName("descuento_aplicado");
            entity.Property(e => e.Precio)
                .HasMaxLength(45)
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_categoria");
            entity.Property(e => e.CantidadCategorias)
                .HasMaxLength(45)
                .HasColumnName("cantidad_categorias");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(45)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.Clientecol)
                .HasMaxLength(45)
                .HasColumnName("clientecol");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(45)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => new { e.IdEnvios, e.PedidosIdPedido, e.PedidosProductosIdProducto, e.PedidosClienteIdCliente })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("envios");

            entity.HasIndex(e => new { e.PedidosIdPedido, e.PedidosProductosIdProducto, e.PedidosClienteIdCliente }, "fk_Envios_pedidos1_idx");

            entity.Property(e => e.IdEnvios)
                .HasColumnType("int(11)")
                .HasColumnName("id_Envios");
            entity.Property(e => e.PedidosIdPedido)
                .HasColumnType("int(11)")
                .HasColumnName("pedidos_id_pedido");
            entity.Property(e => e.PedidosProductosIdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("pedidos_productos_id_producto");
            entity.Property(e => e.PedidosClienteIdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("pedidos_cliente_id_cliente");
            entity.Property(e => e.DireccionEnvio)
                .HasMaxLength(45)
                .HasColumnName("Direccion_envio");
            entity.Property(e => e.EmpresaEnvio)
                .HasMaxLength(45)
                .HasColumnName("empresa_envio");
            entity.Property(e => e.EstadoEnvio)
                .HasMaxLength(45)
                .HasColumnName("Estado_envio");
            entity.Property(e => e.FechaEntregaEstimada)
                .HasMaxLength(45)
                .HasColumnName("fecha_entrega_estimada");
            entity.Property(e => e.FechaEnvio)
                .HasMaxLength(45)
                .HasColumnName("fecha_envio");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Envios)
                .HasForeignKey(d => new { d.PedidosIdPedido, d.PedidosProductosIdProducto, d.PedidosClienteIdCliente })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Envios_pedidos1");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.ToTable("estado");

            entity.Property(e => e.IdEstado)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_estado");

            entity.HasMany(d => d.Pagos).WithMany(p => p.EstadoIdEstados)
                .UsingEntity<Dictionary<string, object>>(
                    "EstadoHasPago",
                    r => r.HasOne<Pago>().WithMany()
                        .HasForeignKey("PagoIdPago", "PagoBoletaIdPago", "PagoBoletaPedidosIdPedido", "PagoBoletaPedidosProductosIdProducto", "PagoBoletaPedidosClienteIdCliente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_estado_has_pago_pago1"),
                    l => l.HasOne<Estado>().WithMany()
                        .HasForeignKey("EstadoIdEstado")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_estado_has_pago_estado1"),
                    j =>
                    {
                        j.HasKey("EstadoIdEstado", "PagoIdPago", "PagoBoletaIdPago", "PagoBoletaPedidosIdPedido", "PagoBoletaPedidosProductosIdProducto", "PagoBoletaPedidosClienteIdCliente")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0 });
                        j.ToTable("estado_has_pago");
                        j.HasIndex(new[] { "EstadoIdEstado" }, "fk_estado_has_pago_estado1_idx");
                        j.HasIndex(new[] { "PagoIdPago", "PagoBoletaIdPago", "PagoBoletaPedidosIdPedido", "PagoBoletaPedidosProductosIdProducto", "PagoBoletaPedidosClienteIdCliente" }, "fk_estado_has_pago_pago1_idx");
                        j.IndexerProperty<int>("EstadoIdEstado")
                            .HasColumnType("int(11)")
                            .HasColumnName("estado_id_estado");
                        j.IndexerProperty<int>("PagoIdPago")
                            .HasColumnType("int(11)")
                            .HasColumnName("pago_id_pago");
                        j.IndexerProperty<int>("PagoBoletaIdPago")
                            .HasColumnType("int(11)")
                            .HasColumnName("pago_boleta_id_pago");
                        j.IndexerProperty<int>("PagoBoletaPedidosIdPedido")
                            .HasColumnType("int(11)")
                            .HasColumnName("pago_boleta_pedidos_id_pedido");
                        j.IndexerProperty<int>("PagoBoletaPedidosProductosIdProducto")
                            .HasColumnType("int(11)")
                            .HasColumnName("pago_boleta_pedidos_productos_id_producto");
                        j.IndexerProperty<int>("PagoBoletaPedidosClienteIdCliente")
                            .HasColumnType("int(11)")
                            .HasColumnName("pago_boleta_pedidos_cliente_id_cliente");
                    });

            entity.HasMany(d => d.Pedidos).WithMany(p => p.EstadoIdEstados)
                .UsingEntity<Dictionary<string, object>>(
                    "EstadoHasPedido",
                    r => r.HasOne<Pedido>().WithMany()
                        .HasForeignKey("PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_estado_has_pedidos_pedidos1"),
                    l => l.HasOne<Estado>().WithMany()
                        .HasForeignKey("EstadoIdEstado")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_estado_has_pedidos_estado1"),
                    j =>
                    {
                        j.HasKey("EstadoIdEstado", "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                        j.ToTable("estado_has_pedidos");
                        j.HasIndex(new[] { "EstadoIdEstado" }, "fk_estado_has_pedidos_estado1_idx");
                        j.HasIndex(new[] { "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente" }, "fk_estado_has_pedidos_pedidos1_idx");
                        j.IndexerProperty<int>("EstadoIdEstado")
                            .HasColumnType("int(11)")
                            .HasColumnName("estado_id_estado");
                        j.IndexerProperty<int>("PedidosIdPedido")
                            .HasColumnType("int(11)")
                            .HasColumnName("pedidos_id_pedido");
                        j.IndexerProperty<int>("PedidosProductosIdProducto")
                            .HasColumnType("int(11)")
                            .HasColumnName("pedidos_productos_id_producto");
                        j.IndexerProperty<int>("PedidosClienteIdCliente")
                            .HasColumnType("int(11)")
                            .HasColumnName("pedidos_cliente_id_cliente");
                    });
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("inventario");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_categoria");
            entity.Property(e => e.CantidadDisponible)
                .HasMaxLength(45)
                .HasColumnName("cantidad_disponible");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(45)
                .HasColumnName("nombre_producto");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => new { e.IdPago, e.BoletaIdPago, e.BoletaPedidosIdPedido, e.BoletaPedidosProductosIdProducto, e.BoletaPedidosClienteIdCliente })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

            entity.ToTable("pago");

            entity.HasIndex(e => new { e.BoletaIdPago, e.BoletaPedidosIdPedido, e.BoletaPedidosProductosIdProducto, e.BoletaPedidosClienteIdCliente }, "fk_pago_boleta1_idx");

            entity.Property(e => e.IdPago)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("id_pago");
            entity.Property(e => e.BoletaIdPago)
                .HasColumnType("int(11)")
                .HasColumnName("boleta_id_pago");
            entity.Property(e => e.BoletaPedidosIdPedido)
                .HasColumnType("int(11)")
                .HasColumnName("boleta_pedidos_id_pedido");
            entity.Property(e => e.BoletaPedidosProductosIdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("boleta_pedidos_productos_id_producto");
            entity.Property(e => e.BoletaPedidosClienteIdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("boleta_pedidos_cliente_id_cliente");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(45)
                .HasColumnName("estado_pago");
            entity.Property(e => e.FechaHora)
                .HasMaxLength(45)
                .HasColumnName("fecha_hora");
            entity.Property(e => e.Monto)
                .HasColumnType("int(11)")
                .HasColumnName("monto");

            entity.HasOne(d => d.Boletum).WithMany(p => p.Pagos)
                .HasForeignKey(d => new { d.BoletaIdPago, d.BoletaPedidosIdPedido, d.BoletaPedidosProductosIdProducto, d.BoletaPedidosClienteIdCliente })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pago_boleta1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.ProductosIdProducto, e.ClienteIdCliente })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("pedidos");

            entity.HasIndex(e => e.ClienteIdCliente, "fk_pedidos_cliente1_idx");

            entity.Property(e => e.IdPedido)
                .HasColumnType("int(11)")
                .HasColumnName("id_pedido");
            entity.Property(e => e.ProductosIdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("productos_id_producto");
            entity.Property(e => e.ClienteIdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("cliente_id_cliente");
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(45)
                .HasColumnName("estado_pedido");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(45)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Total)
                .HasMaxLength(45)
                .HasColumnName("total");

            entity.HasOne(d => d.ClienteIdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedidos_cliente1");

            entity.HasMany(d => d.Productos).WithMany(p => p.Pedidos)
                .UsingEntity<Dictionary<string, object>>(
                    "PedidosHasProducto",
                    r => r.HasOne<Producto>().WithMany()
                        .HasForeignKey("ProductosIdProducto", "ProductosCategoriasIdCategoria", "ProductosInventarioIdCategoria", "ProductosProveedorIdProveedor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_pedidos_has_productos_productos1"),
                    l => l.HasOne<Pedido>().WithMany()
                        .HasForeignKey("PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_pedidos_has_productos_pedidos1"),
                    j =>
                    {
                        j.HasKey("PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente", "ProductosIdProducto", "ProductosCategoriasIdCategoria", "ProductosInventarioIdCategoria", "ProductosProveedorIdProveedor")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0, 0 });
                        j.ToTable("pedidos_has_productos");
                        j.HasIndex(new[] { "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente" }, "fk_pedidos_has_productos_pedidos1_idx");
                        j.HasIndex(new[] { "ProductosIdProducto", "ProductosCategoriasIdCategoria", "ProductosInventarioIdCategoria", "ProductosProveedorIdProveedor" }, "fk_pedidos_has_productos_productos1_idx");
                        j.IndexerProperty<int>("PedidosIdPedido")
                            .HasColumnType("int(11)")
                            .HasColumnName("pedidos_id_pedido");
                        j.IndexerProperty<int>("PedidosProductosIdProducto")
                            .HasColumnType("int(11)")
                            .HasColumnName("pedidos_productos_id_producto");
                        j.IndexerProperty<int>("PedidosClienteIdCliente")
                            .HasColumnType("int(11)")
                            .HasColumnName("pedidos_cliente_id_cliente");
                        j.IndexerProperty<int>("ProductosIdProducto")
                            .HasColumnType("int(11)")
                            .HasColumnName("productos_id_producto");
                        j.IndexerProperty<int>("ProductosCategoriasIdCategoria")
                            .HasColumnType("int(11)")
                            .HasColumnName("productos_categorias_id_categoria");
                        j.IndexerProperty<int>("ProductosInventarioIdCategoria")
                            .HasColumnType("int(11)")
                            .HasColumnName("productos_inventario_id_categoria");
                        j.IndexerProperty<int>("ProductosProveedorIdProveedor")
                            .HasColumnType("int(11)")
                            .HasColumnName("productos_Proveedor_id_Proveedor");
                    });
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.CategoriasIdCategoria, e.InventarioIdCategoria, e.ProveedorIdProveedor })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("productos");

            entity.HasIndex(e => e.ProveedorIdProveedor, "fk_productos_Proveedor1_idx");

            entity.HasIndex(e => e.CategoriasIdCategoria, "fk_productos_categorias1_idx");

            entity.HasIndex(e => e.InventarioIdCategoria, "fk_productos_inventario1_idx");

            entity.Property(e => e.IdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("id_producto");
            entity.Property(e => e.CategoriasIdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("categorias_id_categoria");
            entity.Property(e => e.InventarioIdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("inventario_id_categoria");
            entity.Property(e => e.ProveedorIdProveedor)
                .HasColumnType("int(11)")
                .HasColumnName("Proveedor_id_Proveedor");
            entity.Property(e => e.CantidadProductos)
                .HasMaxLength(45)
                .HasColumnName("cantidad_productos");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");

            entity.HasOne(d => d.CategoriasIdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriasIdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productos_categorias1");

            entity.HasOne(d => d.InventarioIdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.InventarioIdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productos_inventario1");

            entity.HasOne(d => d.ProveedorIdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorIdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productos_Proveedor1");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("proveedor");

            entity.Property(e => e.IdProveedor)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id_Proveedor");
            entity.Property(e => e.Contacto).HasMaxLength(45);
            entity.Property(e => e.Direccion).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Telefono).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
