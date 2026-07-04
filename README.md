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

 ### 2. Restore dependencies
 Bash

 ```
 dotnet restore
 ```

 ### 3. Run the API
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

