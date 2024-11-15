# **Project Documentation - Hotel System**

## **1. Introduction**

The **Hotel System** project is developed using **ASP.NET Core 8** with an emphasis on **Clean Architecture**. The solution is divided into the following applications and layers to ensure a maintainable and scalable structure. The system uses **Oracle Database** and runs in a **Docker** container.

## **2. Project Structure**

The project is divided into the following layers and applications:

- **Hotel.Api**
- **Hotel.Client** (MVC)
- **Hotel.Core**
- **Hotel.Infrastructure**

### **2.1 Hotel.Api**

- **Description**: The API for the hotel system that exposes endpoints for interacting with the application.
- **Purpose**: Provides a public interface for clients (such as the MVC client) to interact with the system via HTTP requests.

### **2.2 Hotel.Client**

- **Description**: A client application based on the **MVC** (Model-View-Controller) pattern that interacts with the Hotel System API.
- **Purpose**: Provides a user interface for clients to interact with the hotel system through a web application.

### **2.3 Hotel.Core**

- **Description**: Contains domain entities, business rules, and domain logic.
- **Purpose**: Represents the core of the application, where the business logic and main entities (business models) are defined.

### **2.4 Hotel.Infrastructure**

- **Description**: Contains specific infrastructure implementations, such as database access and other external services.
- **Purpose**: Provides concrete implementations of the business logic defined in **Core**, such as data access and environment configuration (e.g., connection to the Oracle database).

## **3. Data Flow**

1. **MVC Client Interaction**: The user interacts with the interface provided by the MVC client, which makes HTTP requests to the API.
2. **API Request**: The API receives the request and, using services from the **Infrastructure** layer, performs the necessary operations.
3. **Application Logic**: The API delegates business tasks to the **Core** layer, which handles the domain logic.
4. **Data Persistence**: If necessary, the **Infrastructure** layer interacts with the Oracle database to store or retrieve data.
5. **Response to MVC Client**: The API returns the results to the MVC client for display to the user.

## **4. Configuration and Deployment**

### **4.1 System Requirements**

- **.NET Core 8**: Ensure that version 8 of .NET Core is installed.
- **Oracle Database**: The database used is **Oracle Database**.
- **Docker**: Docker is used to containerize both the application and the database.

### **4.2 Configuration**

#### **Database**

1. **Oracle Database**: The Oracle database must be configured and accessible to the application. If using Docker, ensure that an Oracle container is running.
2. **Connection String**: Configure the connection string in the `appsettings.json` file of the API to point to the Oracle database.

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
       "HotelConnectionString": "User Id=username;Password=password;Data Source=localhost:1521/ORCL;"
     }
   }
   ```

#### **Docker**

1. **Dockerfile**: Ensure that the following `Dockerfile` is used for the **Hotel.Api** application:

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

2. **docker-compose.yml**: Use the following `docker-compose.yml` file to define and run the containers:

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
         - oracle
       entrypoint: ["./wait-for-it.sh", "oracle:1521", "--", "dotnet", "Hotel.Api.dll"]

     oracle:
       image: gvenzl/oracle-xe:latest
       container_name: oracle
       environment:
         - ORACLE_PASSWORD=Your_password_123
       ports:
         - 1521:1521
       volumes:
         - oracle-data:/opt/oracle/oradata

   volumes:
     oracle-data:
   ```

3. **wait-for-it.sh**: This script ensures that the API waits until Oracle is available before starting.

   ```bash
   #!/usr/bin/env bash
   set -e

   # Wait for a service to be available
   host="$1"
   shift
   cmd="$@"

   until nc -z "$host" 1521; do
     >&2 echo "Oracle Database is unavailable - sleeping"
     sleep 1
   done

   >&2 echo "Oracle Database is up - executing command"
   exec $cmd
   ```

   **Note**: Be sure to run `chmod +x wait-for-it.sh` to make the script executable.

### **4.3 Deployment**

1. **Build and Run**: Use Docker commands to build and run the containers:

   ```bash
   docker-compose build
   docker-compose up
   ```

2. **Production Deployment**: Configure the production environment by adjusting Docker configurations and application settings as necessary.

## **5. Contributions**

- **Contribution Guidelines**: Instructions for developers who wish to contribute to the project, including coding standards and the pull request process.
- **Code of Conduct**: Rules and expectations for contributor behavior.

## **6. License**

- **License Type**: MIT.