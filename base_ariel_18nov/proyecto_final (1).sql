-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 18-11-2024 a las 16:16:08
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.1.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `proyecto_final`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `boleta`
--

CREATE TABLE `boleta` (
  `id_pago` int(11) NOT NULL,
  `monto` varchar(45) DEFAULT NULL,
  `metodo_pago` varchar(45) DEFAULT NULL,
  `pedidos_id_pedido` int(11) NOT NULL,
  `pedidos_productos_id_producto` int(11) NOT NULL,
  `pedidos_cliente_id_cliente` int(11) NOT NULL,
  `fecha_hora` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `carro`
--

CREATE TABLE `carro` (
  `id_carro` int(11) NOT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `descuento_aplicado` int(11) DEFAULT NULL,
  `precio` int(11) DEFAULT NULL,
  `pedidos_id_pedido` int(11) NOT NULL,
  `pedidos_productos_id_producto` int(11) NOT NULL,
  `total` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `carro`
--

INSERT INTO `carro` (`id_carro`, `cantidad`, `descuento_aplicado`, `precio`, `pedidos_id_pedido`, `pedidos_productos_id_producto`, `total`) VALUES
(2, 2, NULL, 10000, 1, 1, 20000),
(10, 1, NULL, 10000, 0, 1, 10000),
(11, 1, NULL, 2000, 0, 2, 2000),
(12, 1, NULL, 2000, 0, 3, 2000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categorias`
--

CREATE TABLE `categorias` (
  `id_categoria` int(11) NOT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `nombre_categoria` varchar(45) DEFAULT NULL,
  `cantidad_categorias` int(11) DEFAULT NULL,
  `estado_categoria` enum('activa','inactiva') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `categorias`
--

INSERT INTO `categorias` (`id_categoria`, `descripcion`, `nombre_categoria`, `cantidad_categorias`, `estado_categoria`) VALUES
(1, 'todo tipo de bebestible', 'bebestible', 121, 'activa'),
(3, 'todo tipo de comestible', 'snaks', 121, 'activa'),
(4, 'todo tipo de alcohol', 'alcohol', 121, 'activa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `id_cliente` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `apellido` varchar(45) DEFAULT NULL,
  `correo` varchar(45) DEFAULT NULL,
  `contraseña` varchar(45) DEFAULT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `fecha_registro` datetime DEFAULT NULL,
  `estado_cliente` enum('activo','inactivo') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`id_cliente`, `nombre`, `apellido`, `correo`, `contraseña`, `direccion`, `telefono`, `fecha_registro`, `estado_cliente`) VALUES
(1, 'miguel', 'angel', 'facu3914@gmail.com', 'hola123', NULL, NULL, '2024-11-09 15:27:37', NULL),
(2, 'angel', 'gonales', 'fac201@gmail.com', '1234', NULL, NULL, '2024-11-09 22:49:16', NULL),
(3, 'ariel', 'villalobos', 'ariel.villalobos.garcia@cftmail.cl', 'benjamin10', NULL, NULL, '2024-11-18 08:59:58', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `envios`
--

CREATE TABLE `envios` (
  `id_Envios` int(11) NOT NULL,
  `Direccion_envio` varchar(45) DEFAULT NULL,
  `fecha_envio` varchar(45) DEFAULT NULL,
  `fecha_entrega_estimada` varchar(45) DEFAULT NULL,
  `Estado_envio` varchar(45) DEFAULT NULL,
  `empresa_envio` varchar(45) DEFAULT NULL,
  `pedidos_id_pedido` int(11) NOT NULL,
  `pedidos_productos_id_producto` int(11) NOT NULL,
  `pedidos_cliente_id_cliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado`
--

CREATE TABLE `estado` (
  `id_estado` int(11) NOT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `nombre_estado` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado_has_pago`
--

CREATE TABLE `estado_has_pago` (
  `estado_id_estado` int(11) NOT NULL,
  `pago_id_pago` int(11) NOT NULL,
  `pago_boleta_id_pago` int(11) NOT NULL,
  `pago_boleta_pedidos_id_pedido` int(11) NOT NULL,
  `pago_boleta_pedidos_productos_id_producto` int(11) NOT NULL,
  `pago_boleta_pedidos_cliente_id_cliente` int(11) NOT NULL,
  `observaciones` varchar(45) DEFAULT NULL,
  ` fecha_cambio_estado` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado_has_pedidos`
--

CREATE TABLE `estado_has_pedidos` (
  `estado_id_estado` int(11) NOT NULL,
  `pedidos_id_pedido` int(11) NOT NULL,
  `pedidos_productos_id_producto` int(11) NOT NULL,
  `pedidos_cliente_id_cliente` int(11) NOT NULL,
  `fecha_cambio_estado` datetime DEFAULT NULL,
  `observaciones` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventario`
--

CREATE TABLE `inventario` (
  `id_Inventario` int(11) NOT NULL,
  `cantidad_disponible` int(11) DEFAULT NULL,
  `nombre_producto` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `inventario`
--

INSERT INTO `inventario` (`id_Inventario`, `cantidad_disponible`, `nombre_producto`) VALUES
(1, 10, 'papas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pago`
--

CREATE TABLE `pago` (
  `id_pago` int(11) NOT NULL,
  `monto` int(11) DEFAULT NULL,
  `fecha_hora` datetime DEFAULT NULL,
  `estado_pago` enum('pagado','pendiente') DEFAULT NULL,
  `boleta_id_pago` int(11) NOT NULL,
  `boleta_pedidos_id_pedido` int(11) NOT NULL,
  `boleta_pedidos_productos_id_producto` int(11) NOT NULL,
  `boleta_pedidos_cliente_id_cliente` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedidos`
--

CREATE TABLE `pedidos` (
  `id_pedido` int(11) NOT NULL,
  `total` varchar(45) DEFAULT NULL,
  `metodo_pago` enum('Credito','Debito','PayPal') DEFAULT NULL,
  `estado_pedido` enum('Pendiente','Procesado','Enviado','Completado','Cancelado') DEFAULT NULL,
  `productos_id_producto` int(11) NOT NULL,
  `cliente_id_cliente` int(11) NOT NULL,
  `fecha_pedido` datetime DEFAULT NULL,
  `CodigoPostal` varchar(100) DEFAULT NULL,
  `Region` varchar(100) DEFAULT NULL,
  `Ciudad` varchar(100) DEFAULT NULL,
  `notas` text NOT NULL,
  `pais` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `pedidos`
--

INSERT INTO `pedidos` (`id_pedido`, `total`, `metodo_pago`, `estado_pedido`, `productos_id_producto`, `cliente_id_cliente`, `fecha_pedido`, `CodigoPostal`, `Region`, `Ciudad`, `notas`, `pais`) VALUES
(0, NULL, 'Credito', 'Procesado', 0, 1, '2024-11-09 17:34:15', '', '', '', '', NULL),
(0, '1000', '', 'Pendiente', 1, 1, NULL, '', '', '', '', NULL),
(0, '1000', '', 'Pendiente', 2, 1, NULL, '', '', '', '', NULL),
(0, '1000', '', 'Pendiente', 3, 1, NULL, '', '', '', '', NULL),
(1, '3033', '', 'Pendiente', 1, 1, '2024-11-16 15:28:26', '', '', '', '', NULL),
(2, '5000', '', '', 2, 1, '2024-11-16 15:28:26', '', '', '', '', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pedidos_has_productos`
--

CREATE TABLE `pedidos_has_productos` (
  `pedidos_id_pedido` int(11) NOT NULL,
  `pedidos_productos_id_producto` int(11) NOT NULL,
  `pedidos_cliente_id_cliente` int(11) NOT NULL,
  `productos_id_producto` int(11) NOT NULL,
  `productos_categorias_id_categoria` int(11) NOT NULL,
  `productos_inventario_id_Inventario` int(11) NOT NULL,
  `productos_Proveedor_id_Proveedor` int(11) NOT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `precio` int(11) DEFAULT NULL,
  `pedidos_has_productoscol` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(11) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `ImageUrl` varchar(45) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `cantidad_productos` int(11) DEFAULT NULL,
  `precio` int(11) DEFAULT NULL,
  `categorias_id_categoria` int(11) NOT NULL,
  `Proveedor_id_Proveedor` int(11) NOT NULL,
  `estado_producto` enum('disponible','agotado') DEFAULT NULL,
  `inventario_id_Inventario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_producto`, `Nombre`, `ImageUrl`, `descripcion`, `cantidad_productos`, `precio`, `categorias_id_categoria`, `Proveedor_id_Proveedor`, `estado_producto`, `inventario_id_Inventario`) VALUES
(1, 'papas', '/img/galletas.jpeg', 'papas', 2, 10000, 3, 1, 'disponible', 1),
(2, 'migul', NULL, 'papas fritas', 1, 2000, 3, 1, 'disponible', 1),
(3, 'bebifa', NULL, 'bebidas de todo tipo ', 1, 2000, 4, 1, 'disponible', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE `proveedor` (
  `id_Proveedor` int(11) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Contacto` varchar(45) DEFAULT NULL,
  `Direccion` varchar(45) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `fecha_proveedor` datetime DEFAULT NULL,
  `estado_proveedor` enum('activo','inactivo') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`id_Proveedor`, `Nombre`, `Email`, `Contacto`, `Direccion`, `Telefono`, `fecha_proveedor`, `estado_proveedor`) VALUES
(1, 'migul', 'fasfsdf@gmail.com', 'hola2134', 'safds', '2242343', '2024-11-09 20:47:01', 'activo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `boleta`
--
ALTER TABLE `boleta`
  ADD PRIMARY KEY (`id_pago`,`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`),
  ADD KEY `fk_boleta_pedidos1_idx` (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`);

--
-- Indices de la tabla `carro`
--
ALTER TABLE `carro`
  ADD PRIMARY KEY (`id_carro`,`pedidos_id_pedido`,`pedidos_productos_id_producto`),
  ADD KEY `fk_carro_pedidos1_idx` (`pedidos_id_pedido`,`pedidos_productos_id_producto`);

--
-- Indices de la tabla `categorias`
--
ALTER TABLE `categorias`
  ADD PRIMARY KEY (`id_categoria`);

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`id_cliente`);

--
-- Indices de la tabla `envios`
--
ALTER TABLE `envios`
  ADD PRIMARY KEY (`id_Envios`,`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`),
  ADD KEY `fk_Envios_pedidos1_idx` (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`);

--
-- Indices de la tabla `estado`
--
ALTER TABLE `estado`
  ADD PRIMARY KEY (`id_estado`);

--
-- Indices de la tabla `estado_has_pago`
--
ALTER TABLE `estado_has_pago`
  ADD PRIMARY KEY (`estado_id_estado`,`pago_id_pago`,`pago_boleta_id_pago`,`pago_boleta_pedidos_id_pedido`,`pago_boleta_pedidos_productos_id_producto`,`pago_boleta_pedidos_cliente_id_cliente`),
  ADD KEY `fk_estado_has_pago_pago1_idx` (`pago_id_pago`,`pago_boleta_id_pago`,`pago_boleta_pedidos_id_pedido`,`pago_boleta_pedidos_productos_id_producto`,`pago_boleta_pedidos_cliente_id_cliente`),
  ADD KEY `fk_estado_has_pago_estado1_idx` (`estado_id_estado`);

--
-- Indices de la tabla `estado_has_pedidos`
--
ALTER TABLE `estado_has_pedidos`
  ADD PRIMARY KEY (`estado_id_estado`,`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`),
  ADD KEY `fk_estado_has_pedidos_pedidos1_idx` (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`),
  ADD KEY `fk_estado_has_pedidos_estado1_idx` (`estado_id_estado`);

--
-- Indices de la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD PRIMARY KEY (`id_Inventario`);

--
-- Indices de la tabla `pago`
--
ALTER TABLE `pago`
  ADD PRIMARY KEY (`id_pago`,`boleta_id_pago`,`boleta_pedidos_id_pedido`,`boleta_pedidos_productos_id_producto`,`boleta_pedidos_cliente_id_cliente`),
  ADD KEY `fk_pago_boleta1_idx` (`boleta_id_pago`,`boleta_pedidos_id_pedido`,`boleta_pedidos_productos_id_producto`,`boleta_pedidos_cliente_id_cliente`);

--
-- Indices de la tabla `pedidos`
--
ALTER TABLE `pedidos`
  ADD PRIMARY KEY (`id_pedido`,`productos_id_producto`,`cliente_id_cliente`),
  ADD KEY `fk_pedidos_cliente1_idx` (`cliente_id_cliente`);

--
-- Indices de la tabla `pedidos_has_productos`
--
ALTER TABLE `pedidos_has_productos`
  ADD PRIMARY KEY (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`,`productos_id_producto`,`productos_categorias_id_categoria`,`productos_inventario_id_Inventario`,`productos_Proveedor_id_Proveedor`),
  ADD KEY `fk_pedidos_has_productos_pedidos1_idx` (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`),
  ADD KEY `fk_pedidos_has_productos_productos1_idx` (`productos_id_producto`,`productos_categorias_id_categoria`,`productos_inventario_id_Inventario`,`productos_Proveedor_id_Proveedor`),
  ADD KEY `fk_pedidos_has_productos_productos1` (`productos_id_producto`,`productos_categorias_id_categoria`,`productos_Proveedor_id_Proveedor`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_producto`,`categorias_id_categoria`,`Proveedor_id_Proveedor`,`inventario_id_Inventario`),
  ADD KEY `fk_productos_categorias1_idx` (`categorias_id_categoria`),
  ADD KEY `fk_productos_Proveedor1_idx` (`Proveedor_id_Proveedor`),
  ADD KEY `fk_productos_inventario1_idx` (`inventario_id_Inventario`);

--
-- Indices de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD PRIMARY KEY (`id_Proveedor`);

--
-- Indices de la tabla `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `boleta`
--
ALTER TABLE `boleta`
  MODIFY `id_pago` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `carro`
--
ALTER TABLE `carro`
  MODIFY `id_carro` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `categorias`
--
ALTER TABLE `categorias`
  MODIFY `id_categoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `id_cliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `envios`
--
ALTER TABLE `envios`
  MODIFY `id_Envios` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `estado`
--
ALTER TABLE `estado`
  MODIFY `id_estado` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `estado_has_pago`
--
ALTER TABLE `estado_has_pago`
  MODIFY `estado_id_estado` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `inventario`
--
ALTER TABLE `inventario`
  MODIFY `id_Inventario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `id_pago` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id_producto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  MODIFY `id_Proveedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `boleta`
--
ALTER TABLE `boleta`
  ADD CONSTRAINT `fk_boleta_pedidos1` FOREIGN KEY (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`) REFERENCES `pedidos` (`id_pedido`, `productos_id_producto`, `cliente_id_cliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `carro`
--
ALTER TABLE `carro`
  ADD CONSTRAINT `fk_carro_pedidos1` FOREIGN KEY (`pedidos_id_pedido`,`pedidos_productos_id_producto`) REFERENCES `pedidos` (`id_pedido`, `productos_id_producto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `envios`
--
ALTER TABLE `envios`
  ADD CONSTRAINT `fk_Envios_pedidos1` FOREIGN KEY (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`) REFERENCES `pedidos` (`id_pedido`, `productos_id_producto`, `cliente_id_cliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `estado_has_pago`
--
ALTER TABLE `estado_has_pago`
  ADD CONSTRAINT `fk_estado_has_pago_estado1` FOREIGN KEY (`estado_id_estado`) REFERENCES `estado` (`id_estado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_estado_has_pago_pago1` FOREIGN KEY (`pago_id_pago`,`pago_boleta_id_pago`,`pago_boleta_pedidos_id_pedido`,`pago_boleta_pedidos_productos_id_producto`,`pago_boleta_pedidos_cliente_id_cliente`) REFERENCES `pago` (`id_pago`, `boleta_id_pago`, `boleta_pedidos_id_pedido`, `boleta_pedidos_productos_id_producto`, `boleta_pedidos_cliente_id_cliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `estado_has_pedidos`
--
ALTER TABLE `estado_has_pedidos`
  ADD CONSTRAINT `fk_estado_has_pedidos_estado1` FOREIGN KEY (`estado_id_estado`) REFERENCES `estado` (`id_estado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_estado_has_pedidos_pedidos1` FOREIGN KEY (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`) REFERENCES `pedidos` (`id_pedido`, `productos_id_producto`, `cliente_id_cliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `pago`
--
ALTER TABLE `pago`
  ADD CONSTRAINT `fk_pago_boleta1` FOREIGN KEY (`boleta_id_pago`,`boleta_pedidos_id_pedido`,`boleta_pedidos_productos_id_producto`,`boleta_pedidos_cliente_id_cliente`) REFERENCES `boleta` (`id_pago`, `pedidos_id_pedido`, `pedidos_productos_id_producto`, `pedidos_cliente_id_cliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `pedidos`
--
ALTER TABLE `pedidos`
  ADD CONSTRAINT `fk_pedidos_cliente1` FOREIGN KEY (`cliente_id_cliente`) REFERENCES `cliente` (`id_cliente`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `pedidos_has_productos`
--
ALTER TABLE `pedidos_has_productos`
  ADD CONSTRAINT `fk_pedidos_has_productos_pedidos1` FOREIGN KEY (`pedidos_id_pedido`,`pedidos_productos_id_producto`,`pedidos_cliente_id_cliente`) REFERENCES `pedidos` (`id_pedido`, `productos_id_producto`, `cliente_id_cliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_pedidos_has_productos_productos1` FOREIGN KEY (`productos_id_producto`,`productos_categorias_id_categoria`,`productos_Proveedor_id_Proveedor`) REFERENCES `productos` (`id_producto`, `categorias_id_categoria`, `Proveedor_id_Proveedor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `productos`
--
ALTER TABLE `productos`
  ADD CONSTRAINT `fk_productos_Proveedor1` FOREIGN KEY (`Proveedor_id_Proveedor`) REFERENCES `proveedor` (`id_Proveedor`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_productos_categorias1` FOREIGN KEY (`categorias_id_categoria`) REFERENCES `categorias` (`id_categoria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_productos_inventario1` FOREIGN KEY (`inventario_id_Inventario`) REFERENCES `inventario` (`id_Inventario`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
