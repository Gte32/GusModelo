##Sacamos de donde vamos a usar nuestro docker, en esta prueba de php
##La composicion va FROM imagen (tu lenguaje) :tag (la version en este caso de 8.0 con apache)
FROM php:8.0-apache 

##EXTRA AGREAGDO DESPUES DEL COMPOSER PHP
##AGREGADO PARA UTILIZAR OTRAS LIBRERIAS Y TENER ACTUALIZADO EL CONTENEDOR

##NO SE NECESITAN EN UN DOCKER SIN COMPOSER, O EN GENERAL, SON HERRAMIENTAS DEFAULT PARA TRABAJAR EN UN PROYECTO ELEVADO
## apt-get update: Actualiza la lista de paquetes disponibles
##apt-get install -y: Instala herramientas necesarias, instalas el git, unzip
##rm -rf: Limpia la caché para reducir el tamaño de la imagen
##el && se usa en cada comando para indicar un adicional
RUN apt-get update && apt-install -y \
	git \ ## Permite clonar repositorios desde dentro del contenedor
	unzip \ ##	Permite descomprimir archivos .zip
	&& rm -rf /var/lib/apt/lists/*

##aqui toma el ARCHIVO MAS RECIENTE usr/bin/composer de la IMAGEN COMPOSER, y lo COPIA en nuestro usr/bin/composer
##ahora puedes tener composer como comando global
COPY --from=composer: lastest usr/bin/composer /usr/bin/composer

##Segundo, establecemos de que directorio se va trabajar de donde extraer pues los datos
##En este caso siempre es el var y vamos a trabajar con html porque estamos en php imbecil

WORKDIR /var/www/html

##tras esto trabajamos en el docker-compose.yml RECORDAR EL YML AL FINAL RETROGRADA

##COPIA todo el contenido de nuestro src de nuestra computadora local al contendor, exactamente en var/www/html, indicado en el docker-compose.yml
##quedaria var/www/html/composer.json y var/www/html/index.php, por eso el src/ ., le indica copiar LO DE ADENTRO no la carpeta
COPY src/ .

##activa el modulo mod_rewrite, modulo de php que ayuda a vinculos simplificados
##QUE SIGNIFICA Y PORQUE NO ASI
##a2 = apache2, en = enable, mod = module, apache 2 enable module
##Ya despues solo el nombre simplificado en este caso rewrite
RUN a2enmod rewrite

##no hace verdaderamente nada, es solo documentacion, documenta se expondra EN EL CONTENDOR el puerto 80, como mencionamos en el docker compose.yml
EXPOSE 80