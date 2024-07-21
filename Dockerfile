# Usar una imagen base de .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Configurar el directorio de trabajo
WORKDIR /app

# Copiar el archivo de solución y los archivos de proyecto
COPY *.sln ./
COPY RovisianServerDev.Api/RovisianServerDev.Api.csproj RovisianServerDev.Api/
COPY RovisianServerDev.Application/RovisianServerDev.Application.csproj RovisianServerDev.Application/
COPY RovisianServerDev.Domain/RovisianServerDev.Domain.csproj RovisianServerDev.Domain/
COPY RovisianServerDev.Infrastructure/RovisianServerDev.Infrastructure.csproj RovisianServerDev.Infrastructure/

# Restaurar las dependencias
RUN dotnet restore

# Copiar el resto del código fuente
COPY . ./

# Construir el proyecto
RUN dotnet build -c Release -o /app/build

# Publicar el proyecto
RUN dotnet publish -c Release -o /app/publish

# Usar una imagen base para la ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto por el que se ejecutará la aplicación
EXPOSE 8080

# Configurar el comando de inicio
ENTRYPOINT ["dotnet", "RovisianServerDev.Api.dll"]
