# Customs Management

Customs Management is a project aimed at managing shipment records and operations for customs clearance. The project includes features for creating, editing, listing, and updating shipment records, with a focus on simplifying customs management processes. Built using .NET and Angular, it integrates key functionalities to provide a seamless user experience.

![Customs Management Logo](https://github.com/nilsutt/CustomsManagement/blob/master/client/customs-management-client/src/assets/images/1.png)


## Features

### Backend Features
- Built with **.NET Core** using **ASP.NET Web API**.
- Implements **CQRS** (Command Query Responsibility Segregation) pattern.
- Database operations handled with **Entity Framework Core**.
- Uses **Mediator Pattern** via **MediatR** for clean architecture.
- Exception handling and validation built-in using **FluentValidation**.
- Enum-based product type management for shipments.
- Repository pattern for data access abstraction.
- Uses **PostgreSQL** as the database.


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
- **Node.js** (version 20 or above)
- **Angular CLI** (version 19)
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
   cd src/CustomsManagement.UI
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

### Frontend
1. Navigate to the UI folder:
   ```bash
   cd src/CustomsManagement.UI
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

### Frontend
- **CustomsManagement.UI**: Angular project with components for shipment management.

## Usage

### Shipment Management
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
- **FluentValidation**
- **PostgreSQL**

### Frontend
- **Angular 16**
- **Angular Material**

## Contact
For any inquiries or support, please reach out to [nilsutt](https://github.com/nilsutt).
