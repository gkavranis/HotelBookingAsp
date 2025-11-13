# HotelBookingAsp

A hotel booking management system built with ASP.NET Core, following Clean Architecture principles. This application provides a RESTful API for managing hotel bookings with support for Docker containerization and SQL Server database.

## 📋 Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Technology Stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Docker Setup](#docker-setup)
- [Project Structure](#project-structure)
- [API Documentation](#api-documentation)
- [Future Features](#future-features)
- [Contributing](#contributing)

## ✨ Features

- RESTful API for hotel booking management
- Clean Architecture implementation
- Docker containerization support
- SQL Server 2022 database integration
- Health checks for services
- Containerized development environment

## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

- **Domain Layer**: Core business logic and entities
- **Application Layer**: Use cases and business rules
- **Infrastructure Layer**: Data access
- **API Layer**: RESTful endpoints and presentation logic
- **Contracts Layer**: DTOs and API contracts

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core
- **Language**: C# 
- **Database**: Microsoft SQL Server 2022
- **Containerization**: Docker & Docker Compose
- **Architecture**: Domain Driven Architecture

## 📦 Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- SQL Server (or use the provided Docker container)

## 🚀 Getting Started

### Running Locally (without Docker)

1. **Clone the repository**
   ```bash
   git clone https://github.com/gkavranis/HotelBookingAspPrivate.git
   cd HotelBookingAspPrivate
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   - Update the connection string in `appsettings.json` to point to your SQL Server instance

4. **Run the application**
   ```bash
   dotnet run --project HotelBooking.API
   ```

5. **Access the API**
   - The API will be available at `http://localhost:8080`
   - Swagger documentation: `http://localhost:8080/swagger`

6. **Seed the database with test data** (first run only)
   
   After the application starts, seed the database by calling the seed endpoint: /api/data-management/seed

## 🐳 Docker Setup

### Running with Docker Compose

1. **Build and start containers**
   ```bash
   docker-compose up --build
   ```

2. **Access the services**
   - API: `http://localhost:8080`
   - SQL Server: `localhost:1433`
     - Username: `sa`
     - Password: `attemptStrongP@ssw0rd`

3. **Seed the database with test data** (first run only)
   
   After the application starts, seed the database by calling the seed endpoint: /api/data-management/seed

4. **Stop containers**
   ```bash
   docker-compose down
   ```

5. **Remove volumes (clean database)**
   ```bash
   docker-compose down -v
   ```

### Docker Services

- **hotelbooking.api**: ASP.NET Core API application
- **sqlserver.data**: SQL Server 2022 with health checks
- **hotelnet**: Bridge network for service communication

## 📁 Project Structure

```
HotelBookingAspPrivate/
├── HotelBooking.API/              # Web API project
├── HotelBooking.Application/      # Application layer (use cases)
├── HotelBooking.Contracts/        # DTOs and contracts
├── HotelBooking.Domain/           # Domain entities and business logic
├── HotelBooking.Infrastructure/   # Data access and external services
├── docker-compose.yml             # Docker composition configuration
├── docker-compose.override.yml    # Docker override settings
└── HotelBookingAsp.sln           # Solution file
```

## 📚 API Documentation

Once the application is running, you can access the API documentation:

- **Swagger UI**: Navigate to `http://localhost:8080/swagger` for interactive API documentation

## 🔮 Future Features

- [ ] **Tests**: Unit, integration, and end-to-end testing
- [ ] **Validation**: Input validation and business rule validation
- [ ] **Logging**: Structured logging with Serilog
- [ ] **Authentication**: JWT-based authentication
- [ ] **Permissions**: Role-based access control (RBAC)
- [ ] **Cancelation**: Implement cancelation using cancelation token
- [ ] **Paging**: Pagination support for list endpoints
- [ ] **Sorting**: Sorting capabilities for data retrieval
- [ ] **Rate Limiter**: API rate limiting to prevent abuse
- [ ] **Caching**: Response caching for improved performance

## 📄 License

This project is private and proprietary.

## 👤 Author

**gkavranis**

---

