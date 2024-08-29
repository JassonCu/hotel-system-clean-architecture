# **Documentación del Proyecto - Sistema de Hotel**

## **1. Introducción**

El proyecto "Sistema de Hotel" está desarrollado utilizando ASP.NET Core 8 con un enfoque en la arquitectura limpia. La solución se divide en varias aplicaciones y capas para garantizar una estructura mantenible y escalable. El sistema utiliza SQL Server y se ejecuta en un contenedor Docker.

## **2. Estructura del Proyecto**

El proyecto se divide en las siguientes aplicaciones y capas:

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

- **Descripción**: Contiene los Data Transfer Objects (DTOs) utilizados para la transferencia de datos entre las capas de la aplicación.
- **Propósito**: Facilitar la comunicación entre la capa de presentación y la capa de aplicación sin exponer las entidades del dominio directamente.

### **2.2 Hotel.Api**

- **Descripción**: La API de la aplicación que expone los endpoints para interactuar con el sistema de hotel.
- **Propósito**: Actuar como interfaz pública para que los clientes puedan acceder a las funcionalidades del sistema a través de solicitudes HTTP.

### **2.3 Hotel.Client**

- **Descripción**: Aplicación cliente basada en MVC que interactúa con la API del sistema de hotel.
- **Propósito**: Proporcionar una interfaz de usuario para que los clientes puedan interactuar con el sistema de hotel mediante una aplicación web.

### **2.4 Hotel.Domain**

- **Descripción**: Contiene las entidades del dominio, reglas de negocio y lógica de dominio.
- **Propósito**: Representar el núcleo de la aplicación, donde se define la lógica de negocio y las entidades principales.

### **2.5 Hotel.Infrastructure**

- **Descripción**: Implementaciones específicas de infraestructura, como servicios de terceros, configuración de dependencias y otros componentes que interactúan con el entorno externo.
- **Propósito**: Proporcionar las implementaciones concretas que interactúan con el sistema de archivos, servicios externos y otros recursos de infraestructura.

### **2.6 Hotel.Interface**

- **Descripción**: Define las interfaces que serán implementadas por la capa de infraestructura y utilizadas en la capa de aplicación.
- **Propósito**: Asegurar una separación clara entre la lógica de negocio y las implementaciones concretas, facilitando la inyección de dependencias.

### **2.7 Hotel.Persistence**

- **Descripción**: Contiene la implementación de acceso a datos, incluyendo repositorios y contexto de base de datos.
- **Propósito**: Manejar la persistencia de datos y la comunicación con la base de datos.

### **2.8 Hotel.UseCases**

- **Descripción**: Contiene la lógica específica de los casos de uso de la aplicación.
- **Propósito**: Implementar los casos de uso específicos de la aplicación que encapsulan la lógica de negocio y coordinan la interacción entre la capa de dominio y la capa de presentación.

### **2.9 Hotel.Utils**

- **Descripción**: Contiene utilidades y helpers generales que pueden ser utilizados en diversas partes del proyecto.
- **Propósito**: Proveer funcionalidades auxiliares y comunes que no encajan en otras capas del proyecto.

## **3. Flujo de Datos**

1. **Interacción del Cliente**: El usuario interactúa con la aplicación cliente basada en MVC, que realiza solicitudes a la API.
2. **Solicitud a la API**: La API recibe la solicitud y, a través de los casos de uso, invoca las operaciones necesarias.
3. **Lógica de Aplicación**: Los casos de uso interactúan con las entidades del dominio para realizar la lógica de negocio.
4. **Persistencia de Datos**: Los casos de uso pueden solicitar la persistencia o recuperación de datos a través de los repositorios implementados en la capa de persistencia.
5. **Respuesta al Cliente**: La API devuelve la respuesta al cliente, que es luego presentada en la interfaz de usuario.

## **4. Configuración y Despliegue**

### **4.1 Requisitos del Sistema**

- **.NET Core 8**: Asegúrate de tener la versión 8 de .NET Core instalada.
- **SQL Server**: Se utiliza SQL Server para la gestión de la base de datos.
- **Docker**: Se utiliza Docker para contenerizar la aplicación y la base de datos.

### **4.2 Configuración**

#### **Base de Datos**

1. **SQL Server**: La base de datos SQL Server se encuentra en un contenedor Docker. Asegúrate de que el contenedor esté ejecutándose y accesible para la aplicación.
2. **Cadena de Conexión**: Configura la cadena de conexión en el archivo `appsettings.json` de la API para apuntar al contenedor de SQL Server.

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

1. **Dockerfile**: Asegúrate de tener el siguiente `Dockerfile` para la aplicación `Hotel.Api`:

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

2. **docker-compose.yml**: Utiliza el siguiente archivo `docker-compose.yml` para definir y ejecutar los contenedores.

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

3. **wait-for-it.sh**: Este script asegura que la API espere hasta que SQL Server esté disponible antes de iniciar.

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

   **Nota**: Asegúrate de ejecutar `chmod +x wait-for-it.sh` para hacer el script ejecutable.

### **4.3 Despliegue**

1. **Construcción y Ejecución**: Usa los comandos de Docker para construir y ejecutar los contenedores:

   ```bash
   docker-compose build
   docker-compose up
   ```

2. **Despliegue en Producción**: Configura el entorno de producción ajustando las configuraciones de Docker y los archivos de configuración de la aplicación según sea necesario.

## **5. Contribuciones**

- **Guía de Contribuciones**: Instrucciones para los desarrolladores que deseen contribuir al proyecto, incluyendo normas de codificación y proceso de pull requests.
- **Código de Conducta**: Normas y expectativas para el comportamiento de los colaboradores.

## **6. Licencia**

- **Tipo de Licencia**: MIT.