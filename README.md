 # ShoppingCore API
 The .NET 10 web API backend for the ShoppingCore e-commerce platform ecosystem.

 ## Prerequisites

 - [.NET 10 SDK](https://dotnet.microsoft.com/download)
 - **IDE:** Visual Studio 2022 (v17.13+) OR VS Code (with the *C# Dev Kit* extension to support `.slnx` files)

 ## Project Structure
 Plaintext

 ```
 ├── ShoppingCoreApi.slnx      # Modern XML solution file
 ├── src/
 │   └── ShoppingCoreApi/      # ASP.NET Core Web API project
 └── tests/
	 └── ShoppingCoreApi.Tests/# xUnit test project
 ```

 ## Getting Started

 ### 1. Clone the repository
 Bash

 ```
 git clone https://github.com/shoppingcore/api.git
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
 dotnet run --project src/ShoppingCoreApi/ShoppingCoreApi.csproj
 ```

 ## Running Tests
 Execute the xUnit test suite using the .NET CLI:

 Bash

 ```
 dotnet test
 ```

