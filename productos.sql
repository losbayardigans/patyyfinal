-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-11-2024 a las 00:53:05
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.0.30

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
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(11) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `ImageUrl` varchar(100) DEFAULT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  `cantidad_productos` varchar(45) DEFAULT NULL,
  `precio` int(11) DEFAULT NULL,
  `categorias_id_categoria` int(11) NOT NULL,
  `inventario_id_categoria` int(11) NOT NULL,
  `Proveedor_id_Proveedor` int(11) NOT NULL,
  `estado_producto` enum('disponible','agotado') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_producto`, `Nombre`, `ImageUrl`, `descripcion`, `cantidad_productos`, `precio`, `categorias_id_categoria`, `inventario_id_categoria`, `Proveedor_id_Proveedor`, `estado_producto`) VALUES
(2, '', '/img/snacks.jpg', 'Producto de prueba', '10', 5, 1, 1, 1, NULL),
(3, '', '/img/galletas.jpeg', 'Producto de prueba', '10', 50, 1, 1, 1, NULL),
(4, '', NULL, 'Producto de prueba', '10', 5, 1, 1, 1, NULL),
(6, '', NULL, 'Producto de prueba', '10', 5, 1, 1, 1, NULL),
(7, '', NULL, 'Producto de prueba', '10', 5, 1, 1, 1, NULL),
(8, '', NULL, 'Producto de prueba', '10', 5, 1, 1, 1, NULL),
(9, '', NULL, 'Producto de prueba', '10', NULL, 1, 1, 1, NULL),
(10, '', NULL, 'Producto de prueba', '10', NULL, 1, 1, 1, NULL);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_producto`,`categorias_id_categoria`,`inventario_id_categoria`,`Proveedor_id_Proveedor`),
  ADD KEY `fk_productos_categorias1_idx` (`categorias_id_categoria`),
  ADD KEY `fk_productos_inventario1_idx` (`inventario_id_categoria`),
  ADD KEY `fk_productos_Proveedor1_idx` (`Proveedor_id_Proveedor`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id_producto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `productos`
--
ALTER TABLE `productos`
  ADD CONSTRAINT `fk_productos_Proveedor1` FOREIGN KEY (`Proveedor_id_Proveedor`) REFERENCES `proveedor` (`id_Proveedor`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_productos_categorias1` FOREIGN KEY (`categorias_id_categoria`) REFERENCES `categorias` (`id_categoria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_productos_inventario1` FOREIGN KEY (`inventario_id_categoria`) REFERENCES `inventario` (`id_categoria`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
