use tienda;

-- 1. Mostrar todos los productos
Select * from producto;

-- 2. Mostrar unicamente el nombre y precio de los productos
select nombre as "Nombre Del Producto",  precio as "Precio" from producto;

-- 3. Mostrar los productos cuyo precio sea mayor a 200
select * from producto where precio>200;

-- 4. Mostrar los productos cuyo precio sea diferente de 180
select * from producto where precio<>180;

-- 5. Mostrar los productos de los fabricantes 1,2 o 3 utilizando el operador I
select * from producto where id_fabricante in(1,2,3);
select * from producto where id_fabricante = 1 or id_fabricante = 2 or id_fabricante = 3;

-- 6. Mostrar los productos cuyo precio esté entre 100 y 250
select * from producto where precio between 100 and 250;
select * from producto where precio >= 100 and precio <= 250;

-- 7.  Mostrar los prooductos cuyo nombre comience con la letra M.alter
select * from producto where nombre like "M%";

-- 8. Mostrar los productos cuyo nombre termine con GB
select * from producto where nombre like "%GB";

-- 9. Mostrar los productos que contengan la palabra LED
select * from producto where nombre like "%LED%";

-- 10. Mostrar los productos cuyo nombre contenga "Monitor" y cuestan menos de 230
select * from producto where nombre like "%Monitor%"  and  precio<230;

-- 11. Mostrar los productos que peretenezca al fabricante 1 y cuesten menos de 230
-- o que pertenezcan al fabricante 2
select * from producto where (id_fabricante = 1 and precio<230) or id_fabricante = 2;

-- 12. Mostrar los productos ordenados por id_fabricante asc y precio desc
select * from producto order by id_fabricante asc, precio desc;

-- 13. Insertar nuevo productos
-- Como la PK es incremental no es necesario ponerla
 INSERT INTO producto(nombre, precio, id_fabricante) VALUES("Disco SSD M2 512GB", 150, 5);
-- insert into producto(id, nombre, precio) values(null, "Disco SSD M2 512GB, 150"); -- Si fabricante es


-- 14. Actualizar precio del SSD insertado
update producto set precio =170 where id=12;

-- 15. Eliminar el producto del ejercicio 13
delete from producto where id = 12;

-- 16 Calcular el precio promedio de todos los producto
select round(avg(precio), 2) as "Precio Promedio" from producto;

-- 17 Mostrar el precio del producto mas caro y el precio del producto mas economico
select max(precio) as "Precio mas caro", min(precio) as "Precio mas economico" from producto;

-- 18 Mostrar el numero de productos que tiene cada fabricante
select id_fabricante, count(id_fabricante) as "Cantidad de productos" from producto group by id_fabricante;

-- 19. Mostrar el precio promedio de los productos de cada fabricante
select id_fabricante, round(avg(precio), 2) as "Precio Promedio" from producto group by id_fabricante;

-- 20. Mostrar el precio mas alto y el mas bajo de los productos de cada fabricante
select max(precio) as "Precio mas caro", min(precio) as "Precio mas economico" from producto;

-- 21. Mostrar los fabricantes que tienen más de un producto registrado.
select id_fabricante, count(id_fabricante) as "Cantidad de productos" from producto group by id_fabricante
having count(id_fabricante) > 1;

-- 22 Mostrar los id_fabricantes cuyo precio promedio de productos sea superior a 200
select id_fabricamte, round(avg(precio),2) as "Precio promedio" from producto group by id_fabricante
having avg(precio) < 200;






