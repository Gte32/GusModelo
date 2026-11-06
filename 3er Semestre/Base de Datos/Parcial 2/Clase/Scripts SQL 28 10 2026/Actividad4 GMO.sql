-- PASO 1
show databases;
create database plataforma_cursos;
show databases;
use plataforma_cursos;

-- PASO 2
create table estudiante(
id_estudiante int primary key auto_increment,
nombre varchar(50) not null,
apellido varchar(50) not null,
correo varchar(50) not null unique, 
telefono varchar(15)
);

create table curso(
id_curso int primary key auto_increment,
nombre varchar(100) not null,
descripcion varchar(200),
duracion_horas int not null check (duracion_horas > 0),
precio DECIMAL(10,2) NOT NULL CHECK (precio > 0)
);

CREATE TABLE inscripcion (
    id_inscripcion INT PRIMARY KEY AUTO_INCREMENT,
    id_estudiante INT NOT NULL,
    id_curso INT NOT NULL,
    fecha_inscripcion DATE NOT NULL,
    estado VARCHAR(20) NOT NULL DEFAULT '1',
    FOREIGN KEY (id_estudiante) REFERENCES estudiante(id_estudiante),
    FOREIGN KEY (id_curso) REFERENCES curso(id_curso)
);


-- PASO 3
show tables;
describe estudiante; -- la pk es id estudiante
describe curso; -- la pk es id curso
describe inscripcion; -- la pk es id inscripcion, tiene de fk las otras pk de arriba

-- PASO 4
alter table estudiante
modify nombre VARCHAR(120) NOT NULL;
describe estudiante;

alter table estudiante
add fecha_nacimiento date;
describe estudiante;

ALTER TABLE curso
ADD nivel ENUM('Básico', 'Intermedio', 'Avanzado')
NOT NULL DEFAULT 'Básico';
describe curso;

alter table curso
change descripcion detalle varchar(200);
describe curso;

alter table estudiante
drop column telefono;
describe estudiante;

alter table curso
modify precio DECIMAL(10,2) NOT NULL CHECK (precio >= 0);
describe curso;

-- PARTE 5
describe estudiante;
describe curso;
describe inscripcion;

