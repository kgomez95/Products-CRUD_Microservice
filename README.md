# Products-CRUD_Microservice
Microservicio de un CRUD de productos con Asp.Net Core 6.0.

El objetivo de este proyecto era crear un microservicio, utilizar ApiVersioning para tener varias versiones de un mismo controlador y hacer uso de Swagger para la documentación de la API.

## Requisitos
Es necesario tener instalado todo los siguiente para poder ejecutar el proyecto:
> Visual Studio 2022.

> Sql Server.

> .NET 6.


## Conexión a la base de datos
Seguir los siguientes pasos para especificar los parámetros de conexión de la base de datos:
> Abrir el fichero "*appsettings.json*" del proyecto "*Products_CRUD_Microservice.API.Products*".

> Modificar el config "*ConnectionStrings.DefaultConnection*" y especificar los parámetros de conexión de tu base de datos.


## Ejecutar la migración para crear la base de datos
Una vez descargado o clonado el proyecto es necesario abrirlo con Visual Studio 2022 y seguir los siguientes pasos:
> Abrir la consola de administrador de paquetes.

> Especificar el proyecto por defecto "*Products_CRUD_Microservice.API.Products*".

> Ejecutar "*Update-Database*".


## Estructura del proyecto
> El proyecto principal se llama "*Products_CRUD_Microservice.API.Products*".

> El proyecto de pruebas unitarias se llama "*Products_CRUD_Microservice.API.Products.Tests*".

> El proyecto que ataca a base de datos se llama "*Products_CRUD_Microservice.Repository.Products*".

> El proyecto donde está la lógica del microservicio se llama "*Products-CRUD_Microservice.Services.Products*".

> El proyecto donde están los modelos del microservicio se llama "*Products_CRUD_Microservice.Models.Products*".
