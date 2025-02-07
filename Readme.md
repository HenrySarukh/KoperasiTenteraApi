# Home Assignment - KoperasiTentera

I have not added acceptance of privacy policy, PIN and biometric login within api as they need to be handled on Mobile side.

## Overview

This is a sample **ASP.NET Core 8** application demonstrating the **CQRS (Command Query Responsibility Segregation)** pattern and **Clean Architecture** principles. It serves as a home assignment to showcase scalable and maintainable web application development practices.

## Technologies Used

- **.NET 8**
- **ASP.NET Core 8**
- **CQRS (Command-Query Responsibility Segregation)**
- **Clean Architecture**
- **MediatR** - for handling commands and queries
- **FluentValidation** - for input validation
- **Entity Framework Core**
- **Docker**

## Project Structure

### Solution Layers

1. **API Layer**: 
   - Exposes REST API endpoints.
   - Controllers handle HTTP requests and responses.

2. **Application Layer**: 
   - Contains business logic.
   - Defines **Commands** and **Queries** along with their handlers.

3. **Domain Layer**:
   - Contains core business models and domain logic.

4. **Infrastructure Layer**: 
   - Implements data access (e.g., using Entity Framework Core).
   - Handles external service integration.

5. **Test Layer** (Optional):
   - Contains unit tests for business logic and command/query handlers.

## How to Run

### Prerequisites

- **.NET 8 SDK** or later
- A development environment like **Visual Studio** or **VS Code**
- **SQL Server** or a preferred database for persistence (can be run in Docker)
- **Docker** (optional for containerized setup)
