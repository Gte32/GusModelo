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

-- 7 producto
select * from oficina where pais in ("España","Inglaterra","Francia");

-- 8
select nombre, proveedor, cantidad_en_stock from producto where (cantidad_en_stock <3);

-- 9.
select * from pedido where fecha_entrega like "2009-04%";

-- 10
select codigo_empleado_rep_ventas, count(nombre_cliente) as "Numero de clientes" from cliente
group by codigo_empleado_rep_ventas;

-- 11.
select year(fecha_pago) as año, count(total) as "Numero de Pagos" from pago
group by year(fecha_pago) order by año;

-- 12.
select codigo_cliente, count(fecha_pedido) as pedido from pedido where estado = "Entregado"
group by codigo_cliente; -- hace falta agrupar al contar

-- 13. 
select proveedor, sum(precio_venta) as venta_total from producto
group by proveedor;


-- 14. 
select max(precio_venta) as precio_producto_caro, min(precio_venta) as precio_producto_barato from producto;

-- 15.
select sum(cantidad*precio_unidad) as venta_total, codigo_pedido from detalle_pedido
group by codigo_pedido;

-- 16.
select * from gama_producto;
insert into gama_producto values("Prueba", "descripcion de prueba", "html de prueba", "imagen de prueba");

-- 17. 
 update producto set precio_venta = precio_venta*0.90
where gama = "Herramientas";
select * from producto;

-- 18.
update cliente set nombre_contacto = "Daniel Martínez"
where codigo_cliente = 1;
select * from cliente;

-- 19. 
delete from gama_producto where gama = "Prueba";
select * from gama_producto;

-- 20. 
select * from pago;
update pago set total = 0 where codigo_cliente = 38;