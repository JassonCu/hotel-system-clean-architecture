# **Project Documentation - Hotel System**

## **1. Introduction**

The "Hotel System" project is developed using ASP.NET Core 8 with a focus on Clean Architecture. The solution is divided into several applications and layers to ensure a maintainable and scalable structure. The system uses SQL Server and runs in a Docker container.

## **2. Project Structure**

The project is divided into the following applications and layers:

- **Application.DTOS**
- **Hotel.Api**
- **Hotel.Client**
- **Hotel.Domain**
- **Hotel.Infrastructure**
- **Hotel.Interface**
- **Hotel.Persistence**
- **Hotel.UseCases**
- **Hotel.Utils**

### **2.1 Application.DTOS**

- **Description**: Contains the Data Transfer Objects (DTOs) used for data transfer between application layers.
- **Purpose**: Facilitate communication between the presentation layer and the application layer without exposing domain entities directly.

### **2.2 Hotel.Api**

- **Description**: The API of the application that exposes endpoints to interact with the hotel system.
- **Purpose**: Serve as the public interface for clients to access the system’s functionalities through HTTP requests.

### **2.3 Hotel.Client**

- **Description**: MVC-based client application that interacts with the hotel system API.
- **Purpose**: Provide a user interface for clients to interact with the hotel system through a web application.

### **2.4 Hotel.Domain**

- **Description**: Contains domain entities, business rules, and domain logic.
- **Purpose**: Represent the core of the application, defining business logic and main entities.

### **2.5 Hotel.Infrastructure**

- **Description**: Contains specific infrastructure implementations, such as third-party services, dependency configurations, and other components interacting with the external environment.
- **Purpose**: Provide concrete implementations that interact with file systems, external services, and other infrastructure resources.

### **2.6 Hotel.Interface**

- **Description**: Defines interfaces that will be implemented by the infrastructure layer and used in the application layer.
- **Purpose**: Ensure a clear separation between business logic and concrete implementations, facilitating dependency injection.

### **2.7 Hotel.Persistence**

- **Description**: Contains data access implementations, including repositories and database context.
- **Purpose**: Handle data persistence and communication with the database.

### **2.8 Hotel.UseCases**

- **Description**: Contains specific use case logic of the application.
- **Purpose**: Implement specific application use cases that encapsulate business logic and coordinate interactions between the domain layer and the presentation layer.

### **2.9 Hotel.Utils**

- **Description**: Contains general utilities and helpers that can be used in various parts of the project.
- **Purpose**: Provide auxiliary and common functionalities that do not fit into other project layers.

## **3. Data Flow**

1. **Client Interaction**: The user interacts with the MVC-based client application, which sends requests to the API.
2. **API Request**: The API receives the request and, through the use cases, invokes the necessary operations.
3. **Application Logic**: The use cases interact with domain entities to perform business logic.
4. **Data Persistence**: Use cases may request data persistence or retrieval through repositories implemented in the persistence layer.
5. **Client Response**: The API returns the response to the client, which is then presented in the user interface.

## **4. Configuration and Deployment**

### **4.1 System Requirements**

- **.NET Core 8**: Ensure you have .NET Core version 8 installed.
- **SQL Server**: SQL Server is used for database management.
- **Docker**: Docker is used to containerize the application and database.

### **4.2 Configuration**

#### **Database**

1. **SQL Server**: The SQL Server database is running in a Docker container. Ensure that the container is running and accessible to the application.
2. **Connection String**: Configure the connection string in the `appsettings.json` file of the API to point to the SQL Server container.

   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*",
     "ConnectionStrings": {
       "HotelConnectionString": "Server=localhost,1433;Database=HotelSystemExample;User Id=sa;Password=J@ss0n___123;TrustServerCertificate=True;"
     }
   }
   ```

#### **Docker**

1. **Dockerfile**: Ensure you have the following `Dockerfile` for the `Hotel.Api` application:

   ```Dockerfile
   # Use the ASP.NET Core runtime image as the base image
   FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
   WORKDIR /app
   EXPOSE 5077
   ENV ASPNETCORE_URLS=http://+:5077

   # Use the .NET SDK image to build the application
   FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
   ARG configuration=Release
   WORKDIR /src
   COPY ["Hotel.Api/Hotel.Api.csproj", "Hotel.Api/"]
   RUN dotnet restore "Hotel.Api/Hotel.Api.csproj"
   COPY . .
   WORKDIR "/src/Hotel.Api"
   RUN dotnet build "Hotel.Api.csproj" -c $configuration -o /app/build

   # Publish the application
   FROM build AS publish
   ARG configuration=Release
   RUN dotnet publish "Hotel.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

   # Define the final image
   FROM base AS final
   WORKDIR /app
   COPY --from=publish /app/publish .
   ENTRYPOINT ["dotnet", "Hotel.Api.dll"]
   ```

2. **docker-compose.yml**: Use the following `docker-compose.yml` file to define and run the containers.

   ```yaml
   version: '3.9'

   services:
     hotelapi:
       image: hotelapi
       build:
         context: .
         dockerfile: Hotel.Api/Dockerfile
       ports:
         - 5077:5077
       depends_on:
         - sqlserver
       entrypoint: ["./wait-for-it.sh", "sqlserver:1433", "--", "dotnet", "Hotel.Api.dll"]

     sqlserver:
       image: mcr.microsoft.com/mssql/server:2019-latest
       container_name: sqlserver
       environment:
         - ACCEPT_EULA=Y
         - SA_PASSWORD=Your_password_123
       ports:
         - 1433:1433
       volumes:
         - sqlserver-data:/var/opt/mssql

   volumes:
     sqlserver-data:
   ```

3. **wait-for-it.sh**: This script ensures that the API waits until SQL Server is available before starting.

   ```bash
   #!/usr/bin/env bash
   set -e

   # Wait for a service to be available
   host="$1"
   shift
   cmd="$@"

   until nc -z "$host" 1433; do
     >&2 echo "SQL Server is unavailable - sleeping"
     sleep 1
   done

   >&2 echo "SQL Server is up - executing command"
   exec $cmd
   ```

   **Note**: Make sure to run `chmod +x wait-for-it.sh` to make the script executable.

### **4.3 Deployment**

1. **Build and Run**: Use Docker commands to build and run the containers:

   ```bash
   docker-compose build
   docker-compose up
   ```

2. **Production Deployment**: Configure the production environment by adjusting Docker configurations and application configuration files as needed.

## **5. Contributing**

- **Contribution Guidelines**: Instructions for developers who wish to contribute to the project, including coding standards and the pull request process.
- **Code of Conduct**: Guidelines and expectations for contributor behavior.

## **6. License**

- **License Type**: MIT