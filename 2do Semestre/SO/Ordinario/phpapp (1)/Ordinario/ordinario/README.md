# Proyecto Final - Elementos - App

Este proyecto es una aplicación web orquestada con Docker que muestra una lista de elementos, separando las responsabilidades en una arquitectura profesional de tres capas: Frontend, Backend API y Base de Datos.

## Información del Alumno
- **Nombre Completo:** [TU NOMBRE AQUÍ]
- **Materia:** Sistemas Operativos / Programación Web
- **Fecha:** Mayo 2026

## Arquitectura del Proyecto
La aplicación sigue una arquitectura de microservicios simplificada:

1.  **Frontend (PHP):** Una interfaz de usuario que consume datos de la API mediante peticiones HTTP. Está estilizada con CSS moderno y es responsiva.
2.  **Backend API (PHP):** Una API RESTful que se conecta a la base de datos MariaDB para recuperar la información. Devuelve los datos en formato JSON.
3.  **Base de Datos (MariaDB):** Almacena la información de los personajes (nombre, y características opcionales `caracteristica_1` y `caracteristica_2`).
4.  **Orquestación (Docker Compose):** Gestiona el ciclo de vida de los tres contenedores, sus redes internas y volúmenes de datos.

### Nuevas Características
Se han añadido campos flexibles para los personajes:
- **Característica 1:** Atributo opcional que se muestra como una etiqueta azul.
- **Característica 2:** Atributo opcional que se muestra como una etiqueta púrpura.
- **Flexibilidad:** Si un personaje no tiene características asignadas en la base de datos, la interfaz se ajusta automáticamente para mostrar solo el nombre, manteniendo la estética de la tabla.

### Estructura de Carpetas
```text
phpapp/
├── backend/            # Lógica de la API REST
│   ├── config/         # Conexión a DB
│   ├── models/         # Modelos de Datos (Personajes)
│   ├── index.php       # Punto de entrada API
│   └── Dockerfile      # Configuración del contenedor API
├── frontend/           # Interfaz de Usuario
│   ├── index.php       # Página principal
│   └── Dockerfile      # Configuración del contenedor Frontend
├── database/           # Scripts de Base de Datos
│   └── init.sql        # Inicialización de tablas y datos
├── docker-compose.yml  # Orquestador de servicios
└── README.md           # Documentación
```

## Requisitos Previos
- Docker Desktop instalado y en ejecución.
- Docker Compose.

## Instrucciones de Ejecución
Para levantar el proyecto completo, ejecuta el siguiente comando en la raíz del proyecto:

```bash
docker-compose up -d --build
```

Este comando descargará las imágenes necesarias, construirá los contenedores locales y los pondrá en marcha en segundo plano.

## Puertos Utilizados
- **Frontend:** [http://localhost:8081](http://localhost:8081)
- **Backend API:** [http://localhost:8080](http://localhost:8080)
- **Base de Datos:** `localhost:3306` (Puerto interno y externo mapeado)

## Explicación de Componentes

### 1. Extensibilidad
La infraestructura está diseñada para ser fácilmente extensible. Si deseas agregar más elementos (por ejemplo, "Planetas" o "Técnicas"), solo necesitas:
- Agregar una nueva tabla en `database/init.sql`.
- Crear un nuevo modelo en `backend/models/`.
- Crear un nuevo endpoint en el backend o modificar el existente.

### 2. Comentarios en el Código
Todo el código fuente en `backend/` y `frontend/` incluye comentarios detallados explicando la función de cada bloque, desde la conexión a la base de datos hasta la renderización de las tarjetas en el frontend.

### 3. Comunicación Inter-Contenedor
El Frontend se comunica con el Backend usando el nombre del servicio de Docker (`http://api/`), lo que permite que Docker resuelva la IP interna automáticamente sin necesidad de configurar IPs estáticas.
