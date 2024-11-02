using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace patyy.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarIdCategoriaAIdInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "carro",
                columns: table => new
                {
                    id_carro = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pedidos_id_pedido = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    cantidad = table.Column<int>(type: "int(11)", nullable: true),
                    descuento_aplicado = table.Column<int>(type: "int(11)", nullable: true),
                    precio = table.Column<int>(type: "int(11)", nullable: true),
                    Total = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_carro, x.pedidos_id_pedido, x.pedidos_productos_id_producto })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    nombre_categoria = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    cantidad_categorias = table.Column<int>(type: "int(11)", nullable: true),
                    estado_categoria = table.Column<string>(type: "enum('activa','inactiva')", nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_categoria);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    apellido = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    correo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    contraseña = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    direccion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    telefono = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha_registro = table.Column<DateTime>(type: "datetime", nullable: true),
                    estado_cliente = table.Column<string>(type: "enum('activo','inactivo')", nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_cliente);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    nombre_estado = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_estado);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    id_Inventario = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cantidad_disponible = table.Column<int>(type: "int(11)", nullable: true),
                    nombre_producto = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_Inventario);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    id_Proveedor = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Contacto = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Direccion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Telefono = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha_proveedor = table.Column<DateTime>(type: "datetime", nullable: true),
                    estado_proveedor = table.Column<string>(type: "enum('activo','inactivo')", nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_Proveedor);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int(11)", nullable: false),
                    productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    total = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    metodo_pago = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    estado_pedido = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha_pedido = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_pedido, x.productos_id_producto, x.cliente_id_cliente })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_pedidos_cliente1",
                        column: x => x.cliente_id_cliente,
                        principalTable: "cliente",
                        principalColumn: "id_cliente");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    categorias_id_categoria = table.Column<int>(type: "int(11)", nullable: false),
                    inventario_id_Inventario = table.Column<int>(type: "int(11)", nullable: false),
                    Proveedor_id_Proveedor = table.Column<int>(type: "int(11)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    ImageUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    cantidad_productos = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    precio = table.Column<int>(type: "int(11)", nullable: true),
                    estado_producto = table.Column<string>(type: "enum('disponible','agotado')", nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_producto, x.categorias_id_categoria, x.inventario_id_Inventario, x.Proveedor_id_Proveedor })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_productos_Proveedor1",
                        column: x => x.Proveedor_id_Proveedor,
                        principalTable: "proveedor",
                        principalColumn: "id_Proveedor");
                    table.ForeignKey(
                        name: "fk_productos_categorias1",
                        column: x => x.categorias_id_categoria,
                        principalTable: "categorias",
                        principalColumn: "id_categoria");
                    table.ForeignKey(
                        name: "fk_productos_inventario1",
                        column: x => x.inventario_id_Inventario,
                        principalTable: "inventario",
                        principalColumn: "id_Inventario");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "boleta",
                columns: table => new
                {
                    id_pago = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pedidos_id_pedido = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    monto = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    metodo_pago = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha_hora = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_pago, x.pedidos_id_pedido, x.pedidos_productos_id_producto, x.pedidos_cliente_id_cliente })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_boleta_pedidos1",
                        columns: x => new { x.pedidos_id_pedido, x.pedidos_productos_id_producto, x.pedidos_cliente_id_cliente },
                        principalTable: "pedidos",
                        principalColumns: new[] { "id_pedido", "productos_id_producto", "cliente_id_cliente" });
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "envios",
                columns: table => new
                {
                    id_Envios = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pedidos_id_pedido = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    Direccion_envio = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha_envio = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha_entrega_estimada = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    Estado_envio = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    empresa_envio = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_Envios, x.pedidos_id_pedido, x.pedidos_productos_id_producto, x.pedidos_cliente_id_cliente })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_Envios_pedidos1",
                        columns: x => new { x.pedidos_id_pedido, x.pedidos_productos_id_producto, x.pedidos_cliente_id_cliente },
                        principalTable: "pedidos",
                        principalColumns: new[] { "id_pedido", "productos_id_producto", "cliente_id_cliente" });
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "estado_has_pedidos",
                columns: table => new
                {
                    estado_id_estado = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_id_pedido = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    fecha_cambio_estado = table.Column<DateTime>(type: "datetime", nullable: true),
                    observaciones = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.estado_id_estado, x.pedidos_id_pedido, x.pedidos_productos_id_producto, x.pedidos_cliente_id_cliente })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_estado_has_pedidos_estado1",
                        column: x => x.estado_id_estado,
                        principalTable: "estado",
                        principalColumn: "id_estado");
                    table.ForeignKey(
                        name: "fk_estado_has_pedidos_pedidos1",
                        columns: x => new { x.pedidos_id_pedido, x.pedidos_productos_id_producto, x.pedidos_cliente_id_cliente },
                        principalTable: "pedidos",
                        principalColumns: new[] { "id_pedido", "productos_id_producto", "cliente_id_cliente" });
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "pedidos_has_productos",
                columns: table => new
                {
                    pedidos_id_pedido = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    pedidos_cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    productos_categorias_id_categoria = table.Column<int>(type: "int(11)", nullable: false),
                    productos_inventario_id_categoria = table.Column<int>(type: "int(11)", nullable: false),
                    productos_Proveedor_id_Proveedor = table.Column<int>(type: "int(11)", nullable: false),
                    cantidad = table.Column<int>(type: "int(11)", nullable: true),
                    precio = table.Column<int>(type: "int(11)", nullable: true),
                    pedidos_has_productoscol = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.pedidos_id_pedido, x.pedidos_productos_id_producto, x.pedidos_cliente_id_cliente, x.productos_id_producto, x.productos_categorias_id_categoria, x.productos_inventario_id_categoria, x.productos_Proveedor_id_Proveedor })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_pedidos_has_productos_pedidos1",
                        columns: x => new { x.pedidos_id_pedido, x.pedidos_productos_id_producto, x.pedidos_cliente_id_cliente },
                        principalTable: "pedidos",
                        principalColumns: new[] { "id_pedido", "productos_id_producto", "cliente_id_cliente" });
                    table.ForeignKey(
                        name: "fk_pedidos_has_productos_productos1",
                        columns: x => new { x.productos_id_producto, x.productos_categorias_id_categoria, x.productos_inventario_id_categoria, x.productos_Proveedor_id_Proveedor },
                        principalTable: "productos",
                        principalColumns: new[] { "id_producto", "categorias_id_categoria", "inventario_id_Inventario", "Proveedor_id_Proveedor" });
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "pago",
                columns: table => new
                {
                    id_pago = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    boleta_id_pago = table.Column<int>(type: "int(11)", nullable: false),
                    boleta_pedidos_id_pedido = table.Column<int>(type: "int(11)", nullable: false),
                    boleta_pedidos_productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    boleta_pedidos_cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    monto = table.Column<int>(type: "int(11)", nullable: true),
                    fecha_hora = table.Column<DateTime>(type: "datetime", nullable: true),
                    estado_pago = table.Column<string>(type: "enum('pagado','pendiente')", nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id_pago, x.boleta_id_pago, x.boleta_pedidos_id_pedido, x.boleta_pedidos_productos_id_producto, x.boleta_pedidos_cliente_id_cliente })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_pago_boleta1",
                        columns: x => new { x.boleta_id_pago, x.boleta_pedidos_id_pedido, x.boleta_pedidos_productos_id_producto, x.boleta_pedidos_cliente_id_cliente },
                        principalTable: "boleta",
                        principalColumns: new[] { "id_pago", "pedidos_id_pedido", "pedidos_productos_id_producto", "pedidos_cliente_id_cliente" });
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "estado_has_pago",
                columns: table => new
                {
                    estado_id_estado = table.Column<int>(type: "int(11)", nullable: false),
                    pago_id_pago = table.Column<int>(type: "int(11)", nullable: false),
                    pago_boleta_id_pago = table.Column<int>(type: "int(11)", nullable: false),
                    pago_boleta_pedidos_id_pedido = table.Column<int>(type: "int(11)", nullable: false),
                    pago_boleta_pedidos_productos_id_producto = table.Column<int>(type: "int(11)", nullable: false),
                    pago_boleta_pedidos_cliente_id_cliente = table.Column<int>(type: "int(11)", nullable: false),
                    observaciones = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8_general_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    fecha_cambio_estado = table.Column<DateTime>(name: " fecha_cambio_estado", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.estado_id_estado, x.pago_id_pago, x.pago_boleta_id_pago, x.pago_boleta_pedidos_id_pedido, x.pago_boleta_pedidos_productos_id_producto, x.pago_boleta_pedidos_cliente_id_cliente })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0 });
                    table.ForeignKey(
                        name: "fk_estado_has_pago_estado1",
                        column: x => x.estado_id_estado,
                        principalTable: "estado",
                        principalColumn: "id_estado");
                    table.ForeignKey(
                        name: "fk_estado_has_pago_pago1",
                        columns: x => new { x.pago_id_pago, x.pago_boleta_id_pago, x.pago_boleta_pedidos_id_pedido, x.pago_boleta_pedidos_productos_id_producto, x.pago_boleta_pedidos_cliente_id_cliente },
                        principalTable: "pago",
                        principalColumns: new[] { "id_pago", "boleta_id_pago", "boleta_pedidos_id_pedido", "boleta_pedidos_productos_id_producto", "boleta_pedidos_cliente_id_cliente" });
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_boleta_pedidos1_idx",
                table: "boleta",
                columns: new[] { "pedidos_id_pedido", "pedidos_productos_id_producto", "pedidos_cliente_id_cliente" });

            migrationBuilder.CreateIndex(
                name: "fk_carro_pedidos1_idx",
                table: "carro",
                columns: new[] { "pedidos_id_pedido", "pedidos_productos_id_producto" });

            migrationBuilder.CreateIndex(
                name: "fk_Envios_pedidos1_idx",
                table: "envios",
                columns: new[] { "pedidos_id_pedido", "pedidos_productos_id_producto", "pedidos_cliente_id_cliente" });

            migrationBuilder.CreateIndex(
                name: "fk_estado_has_pago_estado1_idx",
                table: "estado_has_pago",
                column: "estado_id_estado");

            migrationBuilder.CreateIndex(
                name: "fk_estado_has_pago_pago1_idx",
                table: "estado_has_pago",
                columns: new[] { "pago_id_pago", "pago_boleta_id_pago", "pago_boleta_pedidos_id_pedido", "pago_boleta_pedidos_productos_id_producto", "pago_boleta_pedidos_cliente_id_cliente" });

            migrationBuilder.CreateIndex(
                name: "fk_estado_has_pedidos_estado1_idx",
                table: "estado_has_pedidos",
                column: "estado_id_estado");

            migrationBuilder.CreateIndex(
                name: "fk_estado_has_pedidos_pedidos1_idx",
                table: "estado_has_pedidos",
                columns: new[] { "pedidos_id_pedido", "pedidos_productos_id_producto", "pedidos_cliente_id_cliente" });

            migrationBuilder.CreateIndex(
                name: "fk_pago_boleta1_idx",
                table: "pago",
                columns: new[] { "boleta_id_pago", "boleta_pedidos_id_pedido", "boleta_pedidos_productos_id_producto", "boleta_pedidos_cliente_id_cliente" });

            migrationBuilder.CreateIndex(
                name: "fk_pedidos_cliente1_idx",
                table: "pedidos",
                column: "cliente_id_cliente");

            migrationBuilder.CreateIndex(
                name: "fk_pedidos_has_productos_pedidos1_idx",
                table: "pedidos_has_productos",
                columns: new[] { "pedidos_id_pedido", "pedidos_productos_id_producto", "pedidos_cliente_id_cliente" });

            migrationBuilder.CreateIndex(
                name: "fk_pedidos_has_productos_productos1_idx",
                table: "pedidos_has_productos",
                columns: new[] { "productos_id_producto", "productos_categorias_id_categoria", "productos_inventario_id_categoria", "productos_Proveedor_id_Proveedor" });

            migrationBuilder.CreateIndex(
                name: "fk_productos_categorias1_idx",
                table: "productos",
                column: "categorias_id_categoria");

            migrationBuilder.CreateIndex(
                name: "fk_productos_inventario1_idx",
                table: "productos",
                column: "inventario_id_Inventario");

            migrationBuilder.CreateIndex(
                name: "fk_productos_Proveedor1_idx",
                table: "productos",
                column: "Proveedor_id_Proveedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carro");

            migrationBuilder.DropTable(
                name: "envios");

            migrationBuilder.DropTable(
                name: "estado_has_pago");

            migrationBuilder.DropTable(
                name: "estado_has_pedidos");

            migrationBuilder.DropTable(
                name: "pedidos_has_productos");

            migrationBuilder.DropTable(
                name: "pago");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "boleta");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
