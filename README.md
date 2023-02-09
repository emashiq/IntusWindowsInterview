# IntusWindowsInterview
## Architectural Followed Pattern `CQRS & MediaTR`
### Project Dependency Framework -> .NET 7.0
### Project Structure
##### Frontend Project -> SalesOrderApp
##### Backend Project  -> SalesOrderApp.Api
##### Database Used    -> Sqlite

#### Project Dependency Flow
##### `SalesOrderApp.Api` ->  `SalesOrderApp.Core` -> `SalesOrderApp.Persistence`

Database is initiated with code first migration and Migration Assembly is `SalesOrderApp.Persistence`

### Project Description
#### Backend Project
From backend project `OrderController` is responsible for consuming all the api request from blazor frontend application. When request reach to `OrderController` specific endpoint then It goes to specific handler using `Mediator`. Then Handler is performing the operation to the database using `Unit Of Work` which perform the operation using `Generic Repository` which defines in `IRepository<T>` and implemented in `Repository<T>`. Finally when all database operation end then we need to execute SaveChanges which perform Entity Framework Core SavesChanges Operation.

Major Used Libraries are,
* Mediator
* AutoMapper
* EntityFrameworkCore
* EntityFrameworkCore.Sqlite

Connection String & Database is located inside `SalesOrderApp.Api` which can be changed by chaning path from ConnectionString. 
`"DefaultConnection": "Data Source=SalesOrderApp.db"`

#### Frontend Project
From frontend project Application starts with home page then we need to navigate to Sales Order Page by clicking from navigation menu `/order-list` where List of Order then it has `Add | Edit | Delete` buttons which are resonsible for events. All the frontend data and ui is maintained with State management tool `Fluxor`. Inside of `StateModule` directory there is Order directory which contains all the state management classes for `Action | Reducer | State`. Another side http request is handled from `IOrderHttpService` which is performing `HTTP` operation to api. 

Major Used Libraries are,
* Microsoft.AspNetCore.Components.WebAssembly
* Fluxor
* Fluxor.Blazor.Web
* Fluxor.Blazor.Web.ReduxDevTools
* Microsoft.AspNetCore.Components.DataAnnotations.Validation
* Microsoft.Extensions.Http

### How to run the projects
1. `https` configuration for launching backend api project. 
2. `http` for frontend api project. 
3. Select Multiple Project Startup by clicking on Solution InterviewIntus Select these two projects to start `SalesOrderApp.Api` & `SalesOrderApp`. 
4. Projects will run successfully.

Note: Now Allow any origin is added because this is a sample project for interview. If need to change the api path then there is file `appsettings.json` inside wwwroot directory then `ApiBasePath` need to change inside json. There is no Database Migration required to run the project because Sqlite is used for plug & play. 

