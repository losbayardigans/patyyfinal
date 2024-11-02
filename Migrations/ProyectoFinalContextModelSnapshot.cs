﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using patyy.Models;

#nullable disable

namespace patyy.Migrations
{
    [DbContext(typeof(ProyectoFinalContext))]
    partial class ProyectoFinalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_general_ci")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("patyy.Models.Boletum", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_pago");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdPago"));

                    b.Property<int>("PedidosIdPedido")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_id_pedido");

                    b.Property<int>("PedidosProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_productos_id_producto");

                    b.Property<int>("PedidosClienteIdCliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_cliente_id_cliente");

                    b.Property<DateTime?>("FechaHora")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_hora");

                    b.Property<string>("MetodoPago")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("metodo_pago");

                    b.Property<string>("Monto")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("monto");

                    b.HasKey("IdPago", "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                    b.HasIndex(new[] { "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente" }, "fk_boleta_pedidos1_idx");

                    b.ToTable("boleta", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Carro", b =>
                {
                    b.Property<int>("IdCarro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_carro");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdCarro"));

                    b.Property<int>("PedidosIdPedido")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_id_pedido");

                    b.Property<int>("PedidosProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_productos_id_producto");

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int(11)")
                        .HasColumnName("cantidad");

                    b.Property<int?>("DescuentoAplicado")
                        .HasColumnType("int(11)")
                        .HasColumnName("descuento_aplicado");

                    b.Property<int?>("Precio")
                        .HasColumnType("int(11)")
                        .HasColumnName("precio");

                    b.Property<int>("Total")
                        .HasColumnType("int(11)");

                    b.HasKey("IdCarro", "PedidosIdPedido", "PedidosProductosIdProducto")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                    b.HasIndex(new[] { "PedidosIdPedido", "PedidosProductosIdProducto" }, "fk_carro_pedidos1_idx");

                    b.ToTable("carro", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_categoria");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<int?>("CantidadCategorias")
                        .HasColumnType("int(11)")
                        .HasColumnName("cantidad_categorias");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("descripcion");

                    b.Property<string>("EstadoCategoria")
                        .HasColumnType("enum('activa','inactiva')")
                        .HasColumnName("estado_categoria");

                    b.Property<string>("NombreCategoria")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombre_categoria");

                    b.HasKey("IdCategoria")
                        .HasName("PRIMARY");

                    b.ToTable("categorias", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_cliente");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("apellido");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("contraseña");

                    b.Property<string>("Correo")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("correo");

                    b.Property<string>("Direccion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("direccion");

                    b.Property<string>("EstadoCliente")
                        .HasColumnType("enum('activo','inactivo')")
                        .HasColumnName("estado_cliente");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_registro");

                    b.Property<string>("Nombre")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("telefono");

                    b.HasKey("IdCliente")
                        .HasName("PRIMARY");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Envio", b =>
                {
                    b.Property<int>("IdEnvios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_Envios");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdEnvios"));

                    b.Property<int>("PedidosIdPedido")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_id_pedido");

                    b.Property<int>("PedidosProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_productos_id_producto");

                    b.Property<int>("PedidosClienteIdCliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_cliente_id_cliente");

                    b.Property<string>("DireccionEnvio")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Direccion_envio");

                    b.Property<string>("EmpresaEnvio")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("empresa_envio");

                    b.Property<string>("EstadoEnvio")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Estado_envio");

                    b.Property<string>("FechaEntregaEstimada")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("fecha_entrega_estimada");

                    b.Property<string>("FechaEnvio")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("fecha_envio");

                    b.HasKey("IdEnvios", "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                    b.HasIndex(new[] { "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente" }, "fk_Envios_pedidos1_idx");

                    b.ToTable("envios", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_estado");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("descripcion");

                    b.Property<string>("NombreEstado")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombre_estado");

                    b.HasKey("IdEstado")
                        .HasName("PRIMARY");

                    b.ToTable("estado", (string)null);
                });

            modelBuilder.Entity("patyy.Models.EstadoHasPago", b =>
                {
                    b.Property<int>("EstadoIdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("estado_id_estado");

                    b.Property<int>("PagoIdPago")
                        .HasColumnType("int(11)")
                        .HasColumnName("pago_id_pago");

                    b.Property<int>("PagoBoletaIdPago")
                        .HasColumnType("int(11)")
                        .HasColumnName("pago_boleta_id_pago");

                    b.Property<int>("PagoBoletaPedidosIdPedido")
                        .HasColumnType("int(11)")
                        .HasColumnName("pago_boleta_pedidos_id_pedido");

                    b.Property<int>("PagoBoletaPedidosProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("pago_boleta_pedidos_productos_id_producto");

                    b.Property<int>("PagoBoletaPedidosClienteIdCliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("pago_boleta_pedidos_cliente_id_cliente");

                    b.Property<DateTime?>("FechaCambioEstado")
                        .HasColumnType("datetime")
                        .HasColumnName(" fecha_cambio_estado");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("observaciones");

                    b.HasKey("EstadoIdEstado", "PagoIdPago", "PagoBoletaIdPago", "PagoBoletaPedidosIdPedido", "PagoBoletaPedidosProductosIdProducto", "PagoBoletaPedidosClienteIdCliente")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0 });

                    b.HasIndex(new[] { "EstadoIdEstado" }, "fk_estado_has_pago_estado1_idx");

                    b.HasIndex(new[] { "PagoIdPago", "PagoBoletaIdPago", "PagoBoletaPedidosIdPedido", "PagoBoletaPedidosProductosIdProducto", "PagoBoletaPedidosClienteIdCliente" }, "fk_estado_has_pago_pago1_idx");

                    b.ToTable("estado_has_pago", (string)null);
                });

            modelBuilder.Entity("patyy.Models.EstadoHasPedido", b =>
                {
                    b.Property<int>("EstadoIdEstado")
                        .HasColumnType("int(11)")
                        .HasColumnName("estado_id_estado");

                    b.Property<int>("PedidosIdPedido")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_id_pedido");

                    b.Property<int>("PedidosProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_productos_id_producto");

                    b.Property<int>("PedidosClienteIdCliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_cliente_id_cliente");

                    b.Property<DateTime?>("FechaCambioEstado")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_cambio_estado");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("observaciones");

                    b.HasKey("EstadoIdEstado", "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                    b.HasIndex(new[] { "EstadoIdEstado" }, "fk_estado_has_pedidos_estado1_idx");

                    b.HasIndex(new[] { "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente" }, "fk_estado_has_pedidos_pedidos1_idx");

                    b.ToTable("estado_has_pedidos", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Inventario", b =>
                {
                    b.Property<int>("IdInventario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_Inventario");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdInventario"));

                    b.Property<int?>("CantidadDisponible")
                        .HasColumnType("int(11)")
                        .HasColumnName("cantidad_disponible");

                    b.Property<string>("NombreProducto")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombre_producto");

                    b.HasKey("IdInventario")
                        .HasName("PRIMARY");

                    b.ToTable("inventario", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_pago");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdPago"));

                    b.Property<int>("BoletaIdPago")
                        .HasColumnType("int(11)")
                        .HasColumnName("boleta_id_pago");

                    b.Property<int>("BoletaPedidosIdPedido")
                        .HasColumnType("int(11)")
                        .HasColumnName("boleta_pedidos_id_pedido");

                    b.Property<int>("BoletaPedidosProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("boleta_pedidos_productos_id_producto");

                    b.Property<int>("BoletaPedidosClienteIdCliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("boleta_pedidos_cliente_id_cliente");

                    b.Property<string>("EstadoPago")
                        .HasColumnType("enum('pagado','pendiente')")
                        .HasColumnName("estado_pago");

                    b.Property<DateTime?>("FechaHora")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_hora");

                    b.Property<int?>("Monto")
                        .HasColumnType("int(11)")
                        .HasColumnName("monto");

                    b.HasKey("IdPago", "BoletaIdPago", "BoletaPedidosIdPedido", "BoletaPedidosProductosIdProducto", "BoletaPedidosClienteIdCliente")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

                    b.HasIndex(new[] { "BoletaIdPago", "BoletaPedidosIdPedido", "BoletaPedidosProductosIdProducto", "BoletaPedidosClienteIdCliente" }, "fk_pago_boleta1_idx");

                    b.ToTable("pago", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_pedido");

                    b.Property<int>("ProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("productos_id_producto");

                    b.Property<int>("ClienteIdCliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("cliente_id_cliente");

                    b.Property<string>("EstadoPedido")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("estado_pedido");

                    b.Property<DateTime?>("FechaPedido")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_pedido");

                    b.Property<string>("MetodoPago")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("metodo_pago");

                    b.Property<string>("Total")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("total");

                    b.HasKey("IdPedido", "ProductosIdProducto", "ClienteIdCliente")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                    b.HasIndex(new[] { "ClienteIdCliente" }, "fk_pedidos_cliente1_idx");

                    b.ToTable("pedidos", (string)null);
                });

            modelBuilder.Entity("patyy.Models.PedidosHasProducto", b =>
                {
                    b.Property<int>("PedidosIdPedido")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_id_pedido");

                    b.Property<int>("PedidosProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_productos_id_producto");

                    b.Property<int>("PedidosClienteIdCliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("pedidos_cliente_id_cliente");

                    b.Property<int>("ProductosIdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("productos_id_producto");

                    b.Property<int>("ProductosCategoriasIdCategoria")
                        .HasColumnType("int(11)")
                        .HasColumnName("productos_categorias_id_categoria");

                    b.Property<int>("ProductosInventarioIdCategoria")
                        .HasColumnType("int(11)")
                        .HasColumnName("productos_inventario_id_categoria");

                    b.Property<int>("ProductosProveedorIdProveedor")
                        .HasColumnType("int(11)")
                        .HasColumnName("productos_Proveedor_id_Proveedor");

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int(11)")
                        .HasColumnName("cantidad");

                    b.Property<string>("PedidosHasProductoscol")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("pedidos_has_productoscol");

                    b.Property<int?>("Precio")
                        .HasColumnType("int(11)")
                        .HasColumnName("precio");

                    b.HasKey("PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente", "ProductosIdProducto", "ProductosCategoriasIdCategoria", "ProductosInventarioIdCategoria", "ProductosProveedorIdProveedor")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0, 0 });

                    b.HasIndex(new[] { "PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente" }, "fk_pedidos_has_productos_pedidos1_idx");

                    b.HasIndex(new[] { "ProductosIdProducto", "ProductosCategoriasIdCategoria", "ProductosInventarioIdCategoria", "ProductosProveedorIdProveedor" }, "fk_pedidos_has_productos_productos1_idx");

                    b.ToTable("pedidos_has_productos", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_producto");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<int>("CategoriasIdCategoria")
                        .HasColumnType("int(11)")
                        .HasColumnName("categorias_id_categoria");

                    b.Property<int>("InventarioIdInventario")
                        .HasColumnType("int(11)")
                        .HasColumnName("inventario_id_Inventario");

                    b.Property<int>("ProveedorIdProveedor")
                        .HasColumnType("int(11)")
                        .HasColumnName("Proveedor_id_Proveedor");

                    b.Property<string>("CantidadProductos")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("cantidad_productos");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("descripcion");

                    b.Property<string>("EstadoProducto")
                        .HasColumnType("enum('disponible','agotado')")
                        .HasColumnName("estado_producto");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int?>("Precio")
                        .HasColumnType("int(11)")
                        .HasColumnName("precio");

                    b.HasKey("IdProducto", "CategoriasIdCategoria", "InventarioIdInventario", "ProveedorIdProveedor")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

                    b.HasIndex(new[] { "ProveedorIdProveedor" }, "fk_productos_Proveedor1_idx");

                    b.HasIndex(new[] { "CategoriasIdCategoria" }, "fk_productos_categorias1_idx");

                    b.HasIndex(new[] { "InventarioIdInventario" }, "fk_productos_inventario1_idx");

                    b.ToTable("productos", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_Proveedor");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IdProveedor"));

                    b.Property<string>("Contacto")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Email")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("EstadoProveedor")
                        .HasColumnType("enum('activo','inactivo')")
                        .HasColumnName("estado_proveedor");

                    b.Property<DateTime?>("FechaProveedor")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_proveedor");

                    b.Property<string>("Nombre")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdProveedor")
                        .HasName("PRIMARY");

                    b.ToTable("proveedor", (string)null);
                });

            modelBuilder.Entity("patyy.Models.Boletum", b =>
                {
                    b.HasOne("patyy.Models.Pedido", "Pedido")
                        .WithMany("Boleta")
                        .HasForeignKey("PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .IsRequired()
                        .HasConstraintName("fk_boleta_pedidos1");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("patyy.Models.Envio", b =>
                {
                    b.HasOne("patyy.Models.Pedido", "Pedido")
                        .WithMany("Envios")
                        .HasForeignKey("PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .IsRequired()
                        .HasConstraintName("fk_Envios_pedidos1");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("patyy.Models.EstadoHasPago", b =>
                {
                    b.HasOne("patyy.Models.Estado", "EstadoIdEstadoNavigation")
                        .WithMany("EstadoHasPagos")
                        .HasForeignKey("EstadoIdEstado")
                        .IsRequired()
                        .HasConstraintName("fk_estado_has_pago_estado1");

                    b.HasOne("patyy.Models.Pago", "Pago")
                        .WithMany("EstadoHasPagos")
                        .HasForeignKey("PagoIdPago", "PagoBoletaIdPago", "PagoBoletaPedidosIdPedido", "PagoBoletaPedidosProductosIdProducto", "PagoBoletaPedidosClienteIdCliente")
                        .IsRequired()
                        .HasConstraintName("fk_estado_has_pago_pago1");

                    b.Navigation("EstadoIdEstadoNavigation");

                    b.Navigation("Pago");
                });

            modelBuilder.Entity("patyy.Models.EstadoHasPedido", b =>
                {
                    b.HasOne("patyy.Models.Estado", "EstadoIdEstadoNavigation")
                        .WithMany("EstadoHasPedidos")
                        .HasForeignKey("EstadoIdEstado")
                        .IsRequired()
                        .HasConstraintName("fk_estado_has_pedidos_estado1");

                    b.HasOne("patyy.Models.Pedido", "Pedido")
                        .WithMany("EstadoHasPedidos")
                        .HasForeignKey("PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .IsRequired()
                        .HasConstraintName("fk_estado_has_pedidos_pedidos1");

                    b.Navigation("EstadoIdEstadoNavigation");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("patyy.Models.Pago", b =>
                {
                    b.HasOne("patyy.Models.Boletum", "Boletum")
                        .WithMany("Pagos")
                        .HasForeignKey("BoletaIdPago", "BoletaPedidosIdPedido", "BoletaPedidosProductosIdProducto", "BoletaPedidosClienteIdCliente")
                        .IsRequired()
                        .HasConstraintName("fk_pago_boleta1");

                    b.Navigation("Boletum");
                });

            modelBuilder.Entity("patyy.Models.Pedido", b =>
                {
                    b.HasOne("patyy.Models.Cliente", "ClienteIdClienteNavigation")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteIdCliente")
                        .IsRequired()
                        .HasConstraintName("fk_pedidos_cliente1");

                    b.Navigation("ClienteIdClienteNavigation");
                });

            modelBuilder.Entity("patyy.Models.PedidosHasProducto", b =>
                {
                    b.HasOne("patyy.Models.Pedido", "Pedido")
                        .WithMany("PedidosHasProductos")
                        .HasForeignKey("PedidosIdPedido", "PedidosProductosIdProducto", "PedidosClienteIdCliente")
                        .IsRequired()
                        .HasConstraintName("fk_pedidos_has_productos_pedidos1");

                    b.HasOne("patyy.Models.Producto", "Producto")
                        .WithMany("PedidosHasProductos")
                        .HasForeignKey("ProductosIdProducto", "ProductosCategoriasIdCategoria", "ProductosInventarioIdCategoria", "ProductosProveedorIdProveedor")
                        .IsRequired()
                        .HasConstraintName("fk_pedidos_has_productos_productos1");

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("patyy.Models.Producto", b =>
                {
                    b.HasOne("patyy.Models.Categoria", "CategoriasIdCategoriaNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriasIdCategoria")
                        .IsRequired()
                        .HasConstraintName("fk_productos_categorias1");

                    b.HasOne("patyy.Models.Inventario", "InventarioIdInventarioNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("InventarioIdInventario")
                        .IsRequired()
                        .HasConstraintName("fk_productos_inventario1");

                    b.HasOne("patyy.Models.Proveedor", "ProveedorIdProveedorNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("ProveedorIdProveedor")
                        .IsRequired()
                        .HasConstraintName("fk_productos_Proveedor1");

                    b.Navigation("CategoriasIdCategoriaNavigation");

                    b.Navigation("InventarioIdInventarioNavigation");

                    b.Navigation("ProveedorIdProveedorNavigation");
                });

            modelBuilder.Entity("patyy.Models.Boletum", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("patyy.Models.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("patyy.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("patyy.Models.Estado", b =>
                {
                    b.Navigation("EstadoHasPagos");

                    b.Navigation("EstadoHasPedidos");
                });

            modelBuilder.Entity("patyy.Models.Inventario", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("patyy.Models.Pago", b =>
                {
                    b.Navigation("EstadoHasPagos");
                });

            modelBuilder.Entity("patyy.Models.Pedido", b =>
                {
                    b.Navigation("Boleta");

                    b.Navigation("Envios");

                    b.Navigation("EstadoHasPedidos");

                    b.Navigation("PedidosHasProductos");
                });

            modelBuilder.Entity("patyy.Models.Producto", b =>
                {
                    b.Navigation("PedidosHasProductos");
                });

            modelBuilder.Entity("patyy.Models.Proveedor", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}