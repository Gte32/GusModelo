-- database/init.sql
CREATE DATABASE IF NOT EXISTS db_personajes;
USE db_personajes;
CREATE TABLE IF NOT EXISTS characters (
  id int(11) unsigned NOT NULL AUTO_INCREMENT,
  name varchar(250) NOT NULL,
  category varchar(100) DEFAULT NULL,
  description text DEFAULT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO characters (name, category, description) VALUES
('Personaje Ejemplo 1', 'Humano', 'Una descripción general para el primer personaje.'),
('Personaje Ejemplo 2', 'Androide', 'Una descripción general para el segundo personaje.'),
('Personaje Ejemplo 3', 'Criatura', 'Una descripción general para el tercer personaje.');
