FROM php:8.2-apache

# Instalación de extensiones necesarias
RUN apt-get update && apt-get install -y \
    libmariadb-dev \
    && docker-php-ext-install mysqli \
    && rm -rf /var/lib/apt/lists/*

# Copiar el código fuente
COPY . /var/www/html/

# Exponer el puerto 80
EXPOSE 80
