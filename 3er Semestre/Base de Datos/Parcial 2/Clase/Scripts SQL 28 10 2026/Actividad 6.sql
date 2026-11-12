use jardineria;

-- 1.  Seleccionar todos los productos
select * from producto;

-- 2. Mostrar datos productos entre 100 y 200
select * from producto where (precio_venta>100) and (precio_venta<200);

-- 3. Mostrar codigo, nombre, proveedor, precio venta, y una nueva columna con el alias "Nuevo precio de venta"
select nombre, precio_venta, precio_venta*1.16 as "precio_IVA" from producto;

-- 4. Mostrar productos con Mimosa ordenados por precio de venta descendiente
select * from producto where nombre like "%Mimosa%" order by precio_venta desc;

-- 5. Mostrar datos de cliento donde el apellido de contacto tenga la terminacion ez
select * from cliente where apellido_contacto like "%ez";

-- 6.  
select * from cliente where  ((pais = "España" and linea_direccion2 is null) or pais = "USA") 
order by ciudad asc, limite_credito desc;

-- 7 
select * from oficina where pais in ("España","Inglaterra","Francia");
