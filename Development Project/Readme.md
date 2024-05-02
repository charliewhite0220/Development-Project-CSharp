# Project Name: Inventory Management System

## Project Overview
This project is an MVC ASP.NET Core application designed to manage product and category inventories for retail businesses. It allows users to add, search, update, and delete products and categories.

## Architecture Description

### Backend
- **APIs**: Built using ASP.NET Core Web API.
- **Business Logic**: Contained in `Sparcpoint.Core`.
- **Data Access**: Managed through `Sparcpoint.Data` implementing `Sparcpoint.SqlServer.Abstractions`.

### Database
- **Technology**: SQL Server
- **Tables**:
  - `Products`: Stores product details.
  - `Categories`: Categorizes products.
  - `ProductAttributes`: Additional metadata for products.

## API Documentation
### Product APIs
- **Add Product**
  - **POST** `/api/v1/products/add-product`
  - **Body**:
    ```json
    {
      "name": "Sample Product",
      "description": "Description here",
      "metadata": {"key1": "value1"}
    }
    ```
  - **Response**:
    ```json
    {
      "productId": 1
    }
    ```

### Setup and Configuration
#### Requirements
- .NET 5 SDK
- Visual Studio 2019 or later
- SQL Server 2019

#### Installation Steps
1. Clone the repository: `git clone URL_HERE`
2. Open solution in Visual Studio.
3. Restore NuGet packages.
4. Update `appsettings.json` with your database connection string.
5. Run the application.
