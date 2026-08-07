# Bookshelf

Bookshelf es una aplicación web desarrollada para el proyecto final del **Curso de Programación .Net** de la Escuela de Organización Industrial.

Desarrollada con **ASP.NET Core Razor Pages** para la gestión y seguimiento de libros. Permite consultar un catálogo, crear una biblioteca personal donde registrar el estado de lectura y la valoración de cada libro, y proponer nuevos títulos para ampliar el catálogo a través un sistema de revisión por parte de un administrador.

## Características

### Usuarios

* Registro e inicio de sesión.
* Cierre de sesión y eliminación de cuenta.
* Consulta del catálogo de libros.
* Seguir y dejar de seguir libros.
* Biblioteca personal.
* Gestión del estado de lectura.
* Valoración personal de los libros.
* Envío de propuestas de nuevos libros.

### Administradores

* Creación de libros.
* Edición de libros.
* Eliminación de libros.
* Gestión de propuestas de libros.
* Aceptación y rechazo de propuestas.

## Tecnologías utilizadas

* **C#**
* **ASP.NET Core Razor Pages**
* **Entity Framework Core**
* **ASP.NET Core Identity**
* **MySQL**
* **Bootstrap 5**
* **SweetAlert2**

## Arquitectura

* **Razor Pages** para la interfaz de usuario.
* **Servicios** para encapsular la lógica.
* **DTOs** para el intercambio de datos entre la interfaz y la lógica.
* **Entity Framework Core** para el acceso a datos.
* **Inyección de dependencias** para desacoplar los componentes de la aplicación.

## Funcionalidades

### Gestión de usuarios

* Registro.
* Inicio de sesión.
* Cierre de sesión.
* Eliminación de cuenta.
* Roles de usuario y administrador.

### Catálogo

* Listado de libros.
* Crear libro (Administrador).
* Editar libro (Administrador).
* Eliminar libro (Administrador).

### Biblioteca personal

* Seguir libros.
* Dejar de seguir libros.
* Estado de lectura:

  * Pendiente.
  * Leyendo.
  * Leído.
* Valoración de 1 a 5 estrellas.

### Propuestas

* Crear propuestas de nuevos libros.
* Listado de propuestas pendientes.
* Aceptar propuestas.
* Rechazar propuestas.

## Modelo de datos

La aplicación se basa en cuatro entidades principales:

* **User**
* **Book**
* **UserBook**
* **BookProposal**

`UserBook` actúa como entidad intermedia entre usuarios y libros, almacenando además el estado de lectura y la valoración personal de cada libro.

Diagrama de la base de datos

```bash
                       +--------------------+
                       |        User        |
                       |--------------------|
                       | PK Id              |
                       | UserName           |
                       | Email              |
                       | ... (Identity)     |
                       +----------+---------+
                                  |
                       1          |         N
                                  |
                 +----------------+----------------+
                 |                                 |
                 |                                 |
       +---------v----------+            +---------v----------+
       |      UserBook      |            |    BookProposal    |
       |--------------------|            |--------------------|
       | PK Id              |            | PK Id              |
       | FK UserId          |            | Title              |
       | FK BookId          |            | Author             |
       | Status             |            | ReleaseDate        |
       | Rating             |            | ISBN               |
       +---------+----------+            | FK UserId          |
                 |                       | Status             |
                 |                       +--------------------+
       N         |          1
                 |
                 |
       +---------v----------+
       |       Book         |
       |--------------------|
       | PK Id              |
       | Title              |
       | Author             |
       | ReleaseDate        |
       | ISBN               |
       +--------------------+
```

## Instalación

### Requisitos

* .NET 10 SDK
* MySQL Server

### Pasos

1. Clonar el repositorio.

```bash
https://github.com/LuisM0112/book-shelf.git
```

2. Acceder al proyecto.

```bash
cd Bookshelf
```

3. Configurar la cadena de conexión a través de variable de entorno, por ejemplo:

Windows

```bash
$env:ConnectionStrings__DefaultConnection="server=localhost;port=[puerto];database=bookshelf;user=root;password=root;"
```

Linux

```bash
export ConnectionStrings__DefaultConnection="server=localhost;port=[puerto];database=bookshelf;user=root;password=root;"
```

5. Aplicar las migraciones.

```bash
dotnet ef database update
```

5. Ejecutar la aplicación.

```bash
dotnet run
```

## Posibles mejoras

* Categorías para los libros del catálogo.
* Portadas de libros.
* Reseñas escritas por los usuarios.
* Recomendaciones de lectura.
* Notificaciones para propuestas aceptadas o rechazadas.
* Estadísticas de uso para administradores.
* Pruebas unitarias y de integración.

---
