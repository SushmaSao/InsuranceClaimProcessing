#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ClaimProcessingService.API/ClaimProcessingService.API.csproj", "ClaimProcessingService.API/"]
COPY ["ClaimProcessingService.Application/ClaimProcessingService.Application.csproj", "ClaimProcessingService.Application/"]
COPY ["ClaimProcessingService.Domain/ClaimProcessingService.Domain.csproj", "ClaimProcessingService.Domain/"]
COPY ["Common.Application/Common.Application.csproj", "Common.Application/"]
COPY ["ClaimProcessingService.Infrastructure.Persistence/ClaimProcessingService.Persistence.csproj", "ClaimProcessingService.Infrastructure.Persistence/"]
COPY ["Common.Persistence/Common.Persistence.csproj", "Common.Persistence/"]
RUN dotnet restore "./ClaimProcessingService.API/ClaimProcessingService.API.csproj"
COPY . .
WORKDIR "/src/ClaimProcessingService.API"
RUN dotnet build "./ClaimProcessingService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ClaimProcessingService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClaimProcessingService.API.dll"]