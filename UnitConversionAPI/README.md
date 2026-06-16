# Unit Conversion API

A RESTful ASP.NET Core .NET 8 Web API for converting units of Length, Weight, and Temperature.

---

## Technologies

- ASP.NET Core .NET 8
- C#
- Swagger / OpenAPI
- Dependency Injection
- Middleware
- xUnit
- Moq
- FluentAssertions
- Visual Studio 2022

---

## Features

- Convert Length units
- Convert Weight units
- Convert Temperature units
- Global Exception Middleware
- Dependency Injection
- Swagger UI
- XML Documentation
- Unit Tests

---

## Supported Units

### Length

- Millimeter
- Centimeter
- Meter
- Kilometer
- Inch
- Foot
- Yard
- Mile

### Weight

- Gram
- Kilogram
- Pound
- Ounce

### Temperature

- Celsius
- Fahrenheit
- Kelvin

---

## API Endpoint

POST

/api/UnitConversion/convert

### Request

```json
{
  "fromUnit": "meter",
  "toUnit": "kilometer",
  "value": 2500
}
```

### Response

```json
{
  "fromUnit": "meter",
  "toUnit": "kilometer",
  "inputValue": 2500,
  "result": 2.5,
  "category": "Length"
}
```

---

## Running the Project

Clone the repository

```
git clone <repository-url>
```

Navigate to the project

```
cd UnitConversionAPI
```

Restore packages

```
dotnet restore
```

Run

```
dotnet run
```

Swagger

```
https://localhost:44383/
```

---

## Run Tests

```
dotnet test
```

---
