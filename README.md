# Customs Management

Customs Management is a project aimed at managing shipment records and operations for customs clearance. The project includes features for creating, editing, listing, and updating shipment records, with a focus on simplifying customs management processes. Built using .NET and Angular, it integrates key functionalities to provide a seamless user experience.

![Customs Management Logo](https://github.com/nilsutt/CustomsManagement/blob/master/client/customs-management-client/src/assets/images/1.png)


## Features

### Backend Features
- Built with **.NET Core** using **ASP.NET Web API**.
- Implements **CQRS** (Command Query Responsibility Segregation) pattern.
- Follows **Domain-Driven Design (DDD)** principles.
- Database operations handled with **Entity Framework Core**.
- Uses **Mediator Pattern** via **MediatR** for clean architecture.
- Exception handling and validation built-in using **FluentValidation**.
- Enum-based product type management for shipments.
- Repository pattern for data access abstraction.
- Uses **PostgreSQL** as the database.

### Worker Service Features
- A dedicated **Worker Service** is implemented to manage scheduled tasks.
- **Shipment Status Scheduler**:
  - Updates shipment statuses that remain in "Pending" for more than 3 days to "Delayed" automatically.
  - This feature ensures that shipment statuses remain up-to-date without manual intervention.
- Built using **.NET Worker Service** framework.

### Frontend Features
- Built with **Angular** framework.
- Responsive UI designed with **Angular Material**.
- CRUD operations for shipment management:
    - **Create** shipments with validation.
    - **Update** shipment details.
    - **List** shipments with filtering and sorting.
    - **Delete** shipment records.
- Navigation using Angular Router with sidenav for a user-friendly layout.
- Integration with backend APIs for dynamic data management.
   
## Prerequisites

### Tools Required
- **.NET 8.0 SDK**
- **Node.js** (version 18.19.1 or above)
- **Angular CLI** (version 19.0.4)
- **PostgreSQL**

### Environment Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/nilsutt/CustomsManagement.git
   cd CustomsManagement
   ```
2. Install backend dependencies:
   ```bash
   dotnet restore
   ```
3. Install frontend dependencies:
   ```bash
   cd client/customs-management-client
   npm install
   ```

## Running the Project

### Backend
1. Navigate to the backend folder:
   ```bash
   cd src/CustomsManagement.API
   ```
2. Update the connection string in `appsettings.json` to match your local PostgreSQL configuration:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=YourDatabaseName;Username=YourUsername;Password=YourPassword"
   }
   ```
3. Apply migrations and update the database:
   ```bash
   dotnet ef database update
   ```
4. Run the API:
   ```bash
   dotnet run
   ```
5. The API will be available at `http://localhost:5025`.

### Worker Service
1. Navigate to the Worker Service folder:
   ```bash
   cd src/CustomsManagement.Worker
   ```
2. Run the Worker Service:
   ```bash
   dotnet run
   ```
3. The service will automatically update shipment statuses according to the scheduling logic.

### Frontend
1. Navigate to the UI folder:
   ```bash
   cd client/customs-management-client
   ```
2. Start the Angular development server:
   ```bash
   ng serve
   ```
3. The application will be available at `http://localhost:4200`.
   
## Project Structure

### Backend
- **CustomsManagement.API**: Web API project.
- **CustomsManagement.Application**: Contains business logic and handlers for CQRS.
- **CustomsManagement.Domain**: Core domain entities and enums.
- **CustomsManagement.Infrastructure**: Database context and repository implementations.
- **CustomsManagement.Worker**: Background service for scheduling and automating shipment status updates.

### Frontend
- **customs-management-client**: Angular project with components for customs management.

## Usage

### Customs Management
1. **List Shipments**:
    - View all shipments with sorting and filtering options.
2. **Create Shipment**:
    - Fill in shipment details (e.g., Importer/Exporter, Product Type, Declared Value).
3. **Edit Shipment**:
    - Update details of an existing shipment.
4. **Delete Shipment**:
    - Remove unwanted shipments from the system.

## Key Technologies

### Backend
- **.NET 8.0**
- **Entity Framework Core**
- **MediatR**
-  **Domain-Driven Design (DDD)**
- **FluentValidation**
- **PostgreSQL**

### Frontend
- **Angular 16**
- **Angular Material**

## Contact
For any inquiries or support, please reach out to [nilsutt](https://github.com/nilsutt).
