# BankingCore API

 The .NET 10 web API backend for the BankingCore banking platform ecosystem.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- **IDE:** Visual Studio 2022 (v17.13+) OR VS Code (with the *C# Dev Kit* extension to support `.slnx` files)

## Project Structure

 Plaintext

```
 ├── BankingCoreApi.slnx      # Modern XML solution file
 ├── src/
 │   └── BankingCoreApi/      # ASP.NET Core Web API project
 └── tests/
 	 └── BankingCoreApi.Tests/# xUnit test project
```

## Getting Started

### 1. Clone the repository

 Bash

```
 git clone https://github.com/bankingcore/api.git
 cd api
```

### 2. Local Development Setup

 Configure your local settings before running. Create `src/BankingCoreApi/appsettings.Development.json` with your PostgreSQL connection string:

```json
 {
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=banking_core;Username=postgres;Password=yourpassword"
   },
   "Logging": {
     "LogLevel": {
       "Default": "Information",
       "Microsoft.AspNetCore": "Warning"
     }
   }
 }
```

 Then set the JWT signing key via User Secrets (run once):

```bash
 dotnet user-secrets init --project src/BankingCoreApi
 dotnet user-secrets set "Jwt:SecretKey" "your-secret-key-at-least-32-characters-long" --project src/BankingCoreApi
 dotnet user-secrets set "Jwt:Issuer" "BankingCoreApi" --project src/BankingCoreApi
 dotnet user-secrets set "Jwt:Audience" "BankingCoreApi" --project src/BankingCoreApi
```

 Ensure your PostgreSQL database has the required extensions:

```sql
 CREATE EXTENSION IF NOT EXISTS "pgcrypto";
 CREATE EXTENSION IF NOT EXISTS "citext";
```

 Apply EF Core migrations to create the schema:

```bash
 dotnet ef database update
```

### 3. Restore dependencies

 Bash

```
 dotnet restore
```

### 4. Run the API

 Bash

```
 dotnet run --project src/BankingCoreApi/BankingCoreApi.csproj
```

## Running Tests

 Execute the xUnit test suite using the .NET CLI:

 Bash

```
 dotnet test
```

dotnet run
