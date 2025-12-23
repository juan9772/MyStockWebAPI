# MyStockWebAPI: API de Gestión de Stock

[![Licencia: MIT](https://img.shields.io/badge/Licencia-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Una API RESTful completa para la gestión de inventario y control de stock, construida con **Clean Architecture** en ASP.NET Core 8.

## 🚀 Descripción del Proyecto

Esta API proporciona una solución robusta y escalable para la gestión de inventarios, ideal para aplicaciones empresariales. Permite llevar un control detallado de productos, existencias y movimientos de almacén.

### Funcionalidades Principales

-   **Gestión de Productos**: Operaciones CRUD completas para productos (Crear, Leer, Actualizar, Eliminar).
-   **Control de Stock**: Monitorización de cantidades disponibles, reservadas y alertas de stock bajo.
-   **Movimientos de Stock**: Registro de entradas, salidas y ajustes de inventario.
-   **Consultas Avanzadas**: Búsqueda de productos por SKU, categoría y disponibilidad.
-   **Documentación Interactiva**: Endpoints documentados y listos para probar a través de Swagger (OpenAPI).

## 🏛️ Arquitectura

El proyecto sigue los principios de **Clean Architecture**, lo que garantiza un código desacoplado, mantenible y fácil de testear. La separación de responsabilidades se organiza en las siguientes capas:

-   **Domain**: Contiene las entidades de negocio y la lógica de dominio pura (ej. `Product`, `Stock`).
-   **Application**: Orquesta los casos de uso de la aplicación, define DTOs y las interfaces de los servicios.
-   **Infrastructure**: Implementa la lógica de acceso a datos (repositorios) y otros servicios externos.
-   **Presentation (WebAPI)**: Expone los endpoints de la API, maneja las solicitudes HTTP y la interacción con el cliente.

## 💻 Tecnologías Utilizadas

-   **Framework**: ASP.NET Core 8
-   **Arquitectura**: Clean Architecture
-   **Lenguaje**: C#
-   **Pruebas Unitarias**: xUnit y Moq
-   **Documentación**: Swagger (OpenAPI)
-   **Persistencia**: Repositorios en memoria (fácilmente extensible a una base de datos como SQL Server o PostgreSQL con Entity Framework Core).

## 📂 Estructura del Proyecto

```
MyStockWebAPI/
├── Domain/
│   ├── Entities/
│   ├── Repositories/ (Interfaces)
│   └── ...
├── Application/
│   ├── DTOs/
│   ├── Services/ (Interfaces y Implementaciones)
│   └── ...
├── Infrastructure/
│   ├── Repositories/ (Implementaciones)
│   └── DependencyInjection.cs
├── WebAPI/
│   ├── Controllers/
│   ├── Program.cs
│   └── ...
└── Tests/
    └── Application/
        └── Services/
```

## 🏁 Cómo Empezar

Sigue estos pasos para configurar y ejecutar el proyecto en tu entorno local.

### Requisitos Previos

-   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
-   [Git](https://git-scm.com/)

### Pasos de Instalación

1.  **Clona el repositorio:**
    ```bash
    git clone https://github.com/juan9772/MyStockWebAPI.git
    cd MyStockWebAPI
    ```

2.  **Restaura las dependencias de NuGet:**
    ```bash
    dotnet restore
    ```

3.  **Construye el proyecto:**
    ```bash
    dotnet build
    ```

4.  **Ejecuta la aplicación:**
    ```bash
    dotnet run --project MyStock.WebAPI
    ```

La API estará disponible en `https://localhost:7001`.

### Acceso a Swagger

Para explorar y probar los endpoints de forma interactiva, abre tu navegador y ve a:
**[https://localhost:7001/swagger](https://localhost:7001/swagger)**

## 🧪 Ejecutar Pruebas

Para asegurar la calidad y el correcto funcionamiento de la lógica de negocio, puedes ejecutar las pruebas unitarias:

```bash
dotnet test
```

El comando buscará y ejecutará todas las pruebas en la solución, mostrando un resumen de los resultados.

## 📜 Licencia

Este proyecto está distribuido bajo la **Licencia MIT**. Consulta el archivo `LICENSE.txt` para más detalles.

## 📧 Contacto

**Juan Jose Tamayo Mazo**
-   **Email**: jjtamayo97+githubP@gmail.com
-   **LinkedIn**: [www.linkedin.com/in/jjtamayomazo](https://www.linkedin.com/in/jjtamayomazo)
-   **GitHub Issues**: Para reportar bugs o solicitar nuevas funcionalidades, por favor, crea un [issue](https://github.com/juan9772/MyStockWebAPI/issues).