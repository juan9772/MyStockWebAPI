---

# MyStockWebAPI: Stock Management API

A comprehensive RESTful API for inventory management and stock control, built using **Clean Architecture** in ASP.NET Core 8.

## 🚀 Project Description

This API provides a robust and scalable solution for inventory management, ideal for enterprise applications. It allows for detailed tracking of products, existing stock, and warehouse movements.

### Key Features

* **Product Management**: Full CRUD operations for products (Create, Read, Update, Delete).
* **Stock Control**: Monitoring of available and reserved quantities, including low stock alerts.
* **Stock Movements**: Recording of inventory entries, exits, and adjustments.
* **Advanced Queries**: Search products by SKU, category, and availability.
* **Interactive Documentation**: Endpoints are documented and ready to test via Swagger (OpenAPI).

## 🏛️ Architecture

The project follows **Clean Architecture** principles, ensuring decoupled, maintainable, and easily testable code. The separation of concerns is organized into the following layers:

* **Domain**: Contains business entities and pure domain logic (e.g., `Product`, `Stock`).
* **Application**: Orchestrates application use cases, defines DTOs, and service interfaces.
* **Infrastructure**: Implements data access logic (repositories) and other external services.
* **Presentation (WebAPI)**: Exposes API endpoints, handles HTTP requests, and manages client interaction.

## 💻 Technologies Used

* **Framework**: ASP.NET Core 8
* **Architecture**: Clean Architecture
* **Language**: C#
* **Unit Testing**: xUnit and Moq
* **Documentation**: Swagger (OpenAPI)
* **Persistence**: In-memory repositories (easily extensible to databases like SQL Server or PostgreSQL using Entity Framework Core).

## 📂 Project Structure

```
MyStockWebAPI/
├── Domain/
│   ├── Entities/
│   ├── Repositories/ (Interfaces)
│   └── ...
├── Application/
│   ├── DTOs/
│   ├── Services/ (Interfaces and Implementations)
│   └── ...
├── Infrastructure/
│   ├── Repositories/ (Implementations)
│   └── DependencyInjection.cs
├── WebAPI/
│   ├── Controllers/
│   ├── Program.cs
│   └── ...
└── Tests/
    └── Application/
        └── Services/

```

## 🏁 Getting Started

Follow these steps to configure and run the project in your local environment.

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [Git](https://git-scm.com/)

### Installation Steps

1. **Clone the repository:**
```bash
git clone https://github.com/juan9772/MyStockWebAPI.git
cd MyStockWebAPI

```


2. **Restore NuGet dependencies:**
```bash
dotnet restore

```


3. **Build the project:**
```bash
dotnet build

```


4. **Run the application:**
```bash
dotnet run --project MyStock.WebAPI

```



The API will be available at `https://localhost:7001`.

### Accessing Swagger

To explore and test the endpoints interactively, open your browser and go to:
**[https://localhost:7001/swagger](https://www.google.com/search?q=https://localhost:7001/swagger)**

## 🧪 Running Tests

To ensure quality and correct business logic behavior, you can run the unit tests:

```bash
dotnet test

```

This command will find and execute all tests in the solution, displaying a summary of the results.

## 📜 License

This project is distributed under the **MIT License**. See the `LICENSE.txt` file for more details.

## 📧 Contact

**Juan Jose Tamayo Mazo**

* **Email**: jjtamayo97+githubP@gmail.com
* **LinkedIn**: [www.linkedin.com/in/jjtamayomazo](https://www.linkedin.com/in/jjtamayomazo)
* **GitHub Issues**: To report bugs or request new features, please create an [issue](https://github.com/juan9772/MyStockWebAPI/issues).

---
