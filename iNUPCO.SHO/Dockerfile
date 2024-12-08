# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["iNUPCO.SHO/iNUPCO.SHO.csproj", "iNUPCO.SHO/"]
COPY ["iNUPCO.SHO.DTOs/iNUPCO.SHO.DTOs.csproj", "iNUPCO.SHO.DTOs/"]
COPY ["iNUPCO.SHO.Service/iNUPCO.SHO.Service.csproj", "iNUPCO.SHO.Service/"]
COPY ["iNUPCO.SHO.Data/iNUPCO.SHO.Data.csproj", "iNUPCO.SHO.Data/"]
COPY ["iNUPCO.SHO.Repo/iNUPCO.SHO.Repo.csproj", "iNUPCO.SHO.Repo/"]
RUN dotnet restore "./iNUPCO.SHO/iNUPCO.SHO.csproj"
COPY . .
WORKDIR "/src/iNUPCO.SHO"
RUN dotnet build "./iNUPCO.SHO.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./iNUPCO.SHO.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iNUPCO.SHO.dll"]