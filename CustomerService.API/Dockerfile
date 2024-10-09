#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerService.API/CustomerService.API.csproj", "CustomerService.API/"]
COPY ["CustomerService.Application/CustomerService.Application.csproj", "CustomerService.Application/"]
COPY ["Common.Application/Common.Application.csproj", "Common.Application/"]
COPY ["CustomerService.Core/CustomerService.Domain.csproj", "CustomerService.Core/"]
COPY ["CustomerService.Infrastructure/CustomerService.Persistence.csproj", "CustomerService.Infrastructure/"]
COPY ["Common.Persistence/Common.Persistence.csproj", "Common.Persistence/"]
RUN dotnet restore "./CustomerService.API/CustomerService.API.csproj"
COPY . .
WORKDIR "/src/CustomerService.API"
RUN dotnet build "./CustomerService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CustomerService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerService.API.dll"]