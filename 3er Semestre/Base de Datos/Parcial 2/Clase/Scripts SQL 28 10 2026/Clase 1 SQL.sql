
-- PARTE 1
SHOW DATABASES; -- Mostrar bases de datos
CREATE DATABASE tienda_tecnologica;
SHOW DATABASES;
USE tienda_tecnologica;

-- PARTE 2
CREATE TABLE categoria (
    id_categoria INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL UNIQUE,
    descripcion VARCHAR(200)
);

CREATE TABLE producto (
    id_producto INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    sku VARCHAR(20) NOT NULL UNIQUE,
    precio DECIMAL(10,2) NOT NULL CHECK (precio > 0),
    existencia INT NOT NULL DEFAULT 0 CHECK (existencia >= 0),
    id_categoria INT NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES categoria(id_categoria)
);

-- PARTE 3
SHOW TABLES;
DESCRIBE categoria;
DESCRIBE producto;

-- PARTE 4
-- A
ALTER TABLE producto
MODIFY nombre VARCHAR(150) NOT NULL;
DESCRIBE producto;

-- B
ALTER TABLE producto
ADD codigo_barras VARCHAR(30) AFTER sku;
DESCRIBE producto;

-- C
ALTER TABLE producto
ADD estado ENUM('Disponible', 'Agotado', 'Descontinuado')
NOT NULL DEFAULT 'Disponible';
DESCRIBE producto;

-- D
ALTER TABLE producto
DROP COLUMN codigo_barras;
DESCRIBE producto;

-- F
ALTER TABLE categoria
CHANGE nombre nombre_categoria VARCHAR(100) NOT NULL UNIQUE;

SHOW TABLES;
