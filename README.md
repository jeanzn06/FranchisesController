# Franchise API

## Description

Franchise API is a RESTful backend service developed with ASP.NET Core that allows managing franchises, their branches, and the products available in each branch.

The system supports operations for creating franchises, adding branches, managing products and stock, and retrieving the product with the highest stock per branch.

## Technologies

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Express
- Swagger (OpenAPI)

## Project Structure

The API is structured using a layered approach:

Controllers  
Handle HTTP requests and responses.

Models  
Define the entities used by the application (Franchise, Branch, Product).

Data  
Contains the DbContext used by Entity Framework to manage database access.

## Database

The application uses SQL Server with Entity Framework Core migrations to manage the database schema.

Main tables:

- Franchises
- Branches
- Products

Relationships:

Franchise  
└── Branch  
  └── Product

## Setup Instructions

1. Clone the repository


git clone <repository-url>


2. Navigate to the project folder


cd Franchise.Api


3. Restore dependencies


dotnet restore


4. Apply database migrations


dotnet ef database update


5. Run the application


dotnet run


The API will start and Swagger UI will be available at:


http://localhost:5155/swagger


## API Endpoints

### Create Franchise

POST /api/franchise

Example body:


{
"name": "McDonalds"
}


---

### Create Branch

POST /api/branches


{
"name": "Sucursal Centro",
"franchiseId": 1
}


---

### Create Product

POST /api/products


{
"name": "Hamburguesa",
"stock": 50,
"branchId": 1
}


---

### Update Product Stock

PUT /api/products/{id}/stock

Example:


PUT /api/products/1/stock?stock=80


---

### Get Top Product by Branch

GET /api/franchise/{id}/top-products

Returns the product with the highest stock for each branch of a franchise.

Example response:


[
{
"branch": "Sucursal Centro",
"topProduct": {
"name": "Hamburguesa",
"stock": 50
}
}
]


## Features

- Create franchises
- Add branches to franchises
- Manage products per branch
- Update product stock
- Retrieve the product with the highest stock per branch

## Author

Technical test implementation using ASP.NET Core and Entity Framework Core.
