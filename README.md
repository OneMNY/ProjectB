# ProjectB
All project under this solution listed here uses .NET 6 (Core).
This solution try to implement SOLID and DRY design practices

Other 3rd party package (NPM) used are:
- Autofac (Dependency Injection)
- Dapper (simple ORM tools)

## BusinessLogicLibrary 
Class library that store the business logic classes and interfaces such as:
- IDatabase : SQL repository that handle the database query
- IOrderParser : Handles data model parsing from/to XML object and serialization

## ClientConsoleApp
Uses BusinessLogicLibrary to get data, serialize XML and consume the Web API by passing the Order XML and getting the total ShippedQty

## WebApi
Exposes an endpoint for receiving the XML and calculate the total ShippedQty listed under Details section of the XML object

