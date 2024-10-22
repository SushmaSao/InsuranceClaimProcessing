#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

# Expose the port your application is running on
#EXPOSE 5001  ## not working in cloud run

# Set environment variables (optional, depending on your use case)
ENV ASPNETCORE_ENVIRONMENT=Development
#ENV ASPNETCORE_HTTP_PORTS=5001  ## not working in cloud run


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IdentityService.API/IdentityService.API.csproj", "IdentityService.API/"]
COPY ["IdentityService.Application/IdentityService.Application.csproj", "IdentityService.Application/"]
COPY ["Common.Application/Common.Application.csproj", "Common.Application/"]
COPY ["IdentityService.Domain/IdentityService.Domain.csproj", "IdentityService.Domain/"]
COPY ["IdentityService.Infrastructure/IdentityService.Infrastructure.csproj", "IdentityService.Infrastructure/"]
COPY ["IdentityService.Persistence/IdentityService.Persistence.csproj", "IdentityService.Persistence/"]
COPY ["Common.Persistence/Common.Persistence.csproj", "Common.Persistence/"]
RUN dotnet restore "./IdentityService.API/IdentityService.API.csproj"
COPY . .
WORKDIR "/src/IdentityService.API"
RUN dotnet build "./IdentityService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IdentityService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.API.dll"]