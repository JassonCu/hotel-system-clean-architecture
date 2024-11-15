# **Documentación del Proyecto - Sistema de Hotel**

## **1. Introducción**

El proyecto "Sistema de Hotel" está desarrollado utilizando **ASP.NET Core 8** con un enfoque en la **arquitectura limpia**. La solución está dividida en las siguientes aplicaciones y capas para garantizar una estructura mantenible y escalable. El sistema utiliza **Oracle Database** y se ejecuta en un contenedor **Docker**.

## **2. Estructura del Proyecto**

El proyecto está dividido en las siguientes capas y aplicaciones:

- **Hotel.Api**
- **Hotel.Client** (MVC)
- **Hotel.Core**
- **Hotel.Infrastructure**

### **2.1 Hotel.Api**

- **Descripción**: La API del sistema de hotel que expone los endpoints para interactuar con la aplicación.
- **Propósito**: Proporciona una interfaz pública para que los clientes (como el cliente MVC) puedan interactuar con el sistema a través de solicitudes HTTP.

### **2.2 Hotel.Client**

- **Descripción**: Aplicación cliente basada en el patrón **MVC** (Model-View-Controller) que interactúa con la API del sistema de hotel.
- **Propósito**: Proporciona una interfaz de usuario para que los clientes puedan interactuar con el sistema de hotel mediante una aplicación web.

### **2.3 Hotel.Core**

- **Descripción**: Contiene las entidades del dominio, reglas de negocio y lógica del dominio.
- **Propósito**: Representa el núcleo de la aplicación, donde se define la lógica de negocio y las entidades principales (modelos de negocio).

### **2.4 Hotel.Infrastructure**

- **Descripción**: Contiene las implementaciones específicas de infraestructura, como el acceso a la base de datos y otros servicios externos.
- **Propósito**: Proporcionar implementaciones concretas de la lógica de negocio definida en **Core**, como el acceso a datos y la configuración del entorno (por ejemplo, conexión a la base de datos Oracle).

## **3. Flujo de Datos**

1. **Interacción del Cliente MVC**: El usuario interactúa con la interfaz proporcionada por el cliente MVC, que realiza solicitudes HTTP a la API.
2. **Solicitud a la API**: La API recibe la solicitud y, mediante los servicios de la capa **Infrastructure**, ejecuta las operaciones necesarias.
3. **Lógica de Aplicación**: La API delega las tareas de negocio en la capa **Core**, que maneja la lógica del dominio.
4. **Persistencia de Datos**: En caso de ser necesario, la capa **Infrastructure** interactúa con la base de datos Oracle para almacenar o recuperar los datos.
5. **Respuesta al Cliente MVC**: La API devuelve los resultados al cliente MVC para que sean presentados al usuario.

## **4. Configuración y Despliegue**

### **4.1 Requisitos del Sistema**

- **.NET Core 8**: Asegúrate de tener la versión 8 de .NET Core instalada.
- **Oracle Database**: La base de datos utilizada es **Oracle Database**.
- **Docker**: Docker se utiliza para contenerizar tanto la aplicación como la base de datos.

### **4.2 Configuración**

#### **Base de Datos**

1. **Oracle Database**: La base de datos Oracle debe estar configurada y accesible para la aplicación. Si se usa Docker, asegúrate de tener un contenedor Oracle en ejecución.
2. **Cadena de Conexión**: Configura la cadena de conexión en el archivo `appsettings.json` de la API para apuntar a la base de datos Oracle.

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
       "HotelConnectionString": "User Id=usuario;Password=contraseña;Data Source=localhost:1521/ORCL;"
     }
   }
   ```

#### **Docker**

1. **Dockerfile**: Asegúrate de tener el siguiente `Dockerfile` para la aplicación **Hotel.Api**:

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

2. **docker-compose.yml**: Utiliza el siguiente archivo `docker-compose.yml` para definir y ejecutar los contenedores:

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

3. **wait-for-it.sh**: Este script asegura que la API espere hasta que Oracle esté disponible antes de iniciar.

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