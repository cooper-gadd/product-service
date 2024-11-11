# Product Service API

A RESTful service that provides product information including product lists, prices, and price-based queries.

## Description

This API provides endpoints to:
- Get a list of all product names
- Find the cheapest product
- Find the most expensive product
- Get the price of a specific product by name

## API Specification (OpenAPI 3.0.0)

```yaml
openapi: 3.0.0
info:
  title: Product Service API
  description: API for managing product information and prices
  version: 1.0.0

servers:
  - url: https://localhost:5009
    description: Development server

paths:
  /Services/Products:
    get:
      summary: Get all product names
      description: Returns a list of all available product names
      responses:
        '200':
          description: Successful operation
          content:
            application/json:
              schema:
                type: array
                items:
                  type: string
              example: ["Apples", "Peaches", "Pumpkin", "Pie"]

  /Services/Products/Cheapest:
    get:
      summary: Get the cheapest product
      description: Returns the product with the lowest price
      responses:
        '200':
          description: Successful operation
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Product'

  /Services/Products/Costliest:
    get:
      summary: Get the most expensive product
      description: Returns the product with the highest price
      responses:
        '200':
          description: Successful operation
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Product'

  /Services/Products/{product}:
    get:
      summary: Get price of specific product
      description: Returns the price of the specified product
      parameters:
        - name: product
          in: path
          required: true
          description: Name of the product
          schema:
            type: string
      responses:
        '200':
          description: Successful operation
          content:
            application/json:
              schema:
                type: number
                format: decimal
              example: 3.99
        '404':
          description: Product not found
          content:
            application/json:
              schema:
                type: null

components:
  schemas:
    Product:
      type: object
      properties:
        id:
          type: integer
          format: int32
        name:
          type: string
        price:
          type: number
          format: decimal
      required:
        - id
        - name
        - price
      example:
        id: 1
        name: "Apples"
        price: 3.99
```

## Getting Started

### Prerequisites
- .NET 8.0 or later
- An IDE (Zed btw)

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the following command:
```bash
dotnet watch
```

### Testing the Application

The application can be tested using Swagger UI at http://localhost:5009/swagger/index.html

## Endpoints

- GET `/Services/Products` - Returns list of all product names
- GET `/Services/Products/Cheapest` - Returns the cheapest product
- GET `/Services/Products/Costliest` - Returns the most expensive product
- GET `/Services/Products/{product}` - Returns the price of the specified product

## Sample Data

The service includes the following sample products:
- Apples: $3.99
- Peaches: $4.05
- Pumpkin: $13.99
- Pie: $8.00
