# FinPilot AI - Backend Dockerfile
# Multi-stage build for optimized production image

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files for restore
COPY FinPilot.sln .
COPY src/FinPilot.API/FinPilot.API.csproj src/FinPilot.API/
COPY src/FinPilot.Application/FinPilot.Application.csproj src/FinPilot.Application/
COPY src/FinPilot.Domain/FinPilot.Domain.csproj src/FinPilot.Domain/
COPY src/FinPilot.Infrastructure/FinPilot.Infrastructure.csproj src/FinPilot.Infrastructure/
COPY src/FinPilot.Shared/FinPilot.Shared.csproj src/FinPilot.Shared/

RUN dotnet restore

# Copy all source and build
COPY . .
RUN dotnet publish src/FinPilot.API -c Release -o /app/publish --no-restore

# Stage 2: Production
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Security: Run as non-root
RUN groupadd -r finpilot && useradd -r -g finpilot finpilot

COPY --from=build /app/publish .

# Create logs directory
RUN mkdir -p /app/Logs && chown -R finpilot:finpilot /app

USER finpilot

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "FinPilot.API.dll"]
