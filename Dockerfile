# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Configurar el directorio de trabajo
WORKDIR /app
EXPOSE 8080
EXPOSE 7206
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RovisianServerDev.Api/RovisianServerDev.Api.csproj", "RovisianServerDev.Api/"]
COPY ["RovisianServerDev.Application/RovisianServerDev.Application.csproj", "RovisianServerDev.Application/"]
COPY ["RovisianServerDev.Domain/RovisianServerDev.Domain.csproj", "RovisianServerDev.Domain/"]
COPY ["RovisianServerDev.Infrastructure/RovisianServerDev.Infrastructure.csproj", "RovisianServerDev.Infrastructure/"]
RUN dotnet restore "RovisianServerDev.Api/RovisianServerDev.Api.csproj"
COPY . .
WORKDIR "/src/RovisianServerDev.Api"
RUN dotnet build "RovisianServerDev.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RovisianServerDev.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RovisianServerDev.Api.dll"]