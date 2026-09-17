-- database/init.sql
-- Script de inicialización para la base de datos

CREATE DATABASE IF NOT EXISTS app_db;
USE app_db;

DROP TABLE IF EXISTS `characters`;

CREATE TABLE `characters` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(250) NOT NULL,
  `caracteristica_1` varchar(250) DEFAULT NULL,
  `caracteristica_2` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

LOCK TABLES `characters` WRITE;

INSERT INTO `characters` (`name`, `caracteristica_1`, `caracteristica_2`)
VALUES
	('Elemento 1', 'Fuego', 'Poderoso'),
	('Elemento 2', 'Agua', 'Curativo'),
	('Elemento 3', 'Tierra', 'Resistente'),
	('Elemento 4', 'Viento', 'Rápido');

UNLOCK TABLES;
