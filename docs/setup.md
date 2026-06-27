# Local Development Setup Guide

## Prerequisites

| Tool | Version | Installation |
|---|---|---|
| Node.js | >= 20.x | [nodejs.org](https://nodejs.org/) |
| .NET SDK | 9.0.x | [dotnet.microsoft.com](https://dotnet.microsoft.com/download) |
| PostgreSQL | 16.x | [postgresql.org](https://www.postgresql.org/) or use Docker |
| Docker | Latest | [docker.com](https://www.docker.com/get-started) |
| Git | Latest | [git-scm.com](https://git-scm.com/) |

---

## Option 1: Docker Setup (Recommended)

The fastest way to get everything running:

```bash
# Clone and enter the project
git clone https://github.com/your-username/finpilot-ai.git
cd finpilot-ai

# Start all services
docker compose -f docker/docker-compose.yml up -d

# Verify services
curl http://localhost:3000        # Frontend
curl http://localhost:5000/health  # Backend health check
curl http://localhost:5000/swagger  # Swagger UI
```

---

## Option 2: Manual Setup

### 1. Database

**Using Docker (recommended):**
```bash
docker run -d \
  --name finpilot-db \
  -e POSTGRES_DB=finpilot_dev \
  -e POSTGRES_USER=finpilot \
  -e POSTGRES_PASSWORD=finpilot_dev_2026 \
  -p 5432:5432 \
  postgres:16-alpine
```

**Using local PostgreSQL:**
```sql
CREATE USER finpilot WITH PASSWORD 'finpilot_dev_2026';
CREATE DATABASE finpilot_dev OWNER finpilot;
```

### 2. Backend

```bash
cd backend

# Restore packages
dotnet restore FinPilot.sln

# Run the API (Development mode)
dotnet run --project src/FinPilot.API

# The API will be available at:
# - http://localhost:5000
# - Swagger: http://localhost:5000/swagger
```

### 3. Frontend

```bash
cd frontend

# Install dependencies
npm install

# Create environment file
cp .env.example .env.local

# Run development server
npm run dev

# The app will be available at http://localhost:3000
```

---

## Service URLs

| Service | URL | Notes |
|---|---|---|
| Frontend | http://localhost:3000 | Next.js dev server |
| Backend API | http://localhost:5000 | ASP.NET Core |
| Swagger UI | http://localhost:5000/swagger | API documentation |
| Health Check | http://localhost:5000/api/v1/health | API health status |
| PostgreSQL | localhost:5432 | Database |

---

## Common Commands

### Frontend
```bash
npm run dev       # Start dev server
npm run build     # Production build
npm run lint      # Run ESLint
```

### Backend
```bash
dotnet build FinPilot.sln               # Build solution
dotnet run --project src/FinPilot.API    # Run API
dotnet test FinPilot.sln                # Run tests
```

### Docker
```bash
docker compose -f docker/docker-compose.yml up -d      # Start all
docker compose -f docker/docker-compose.yml down        # Stop all
docker compose -f docker/docker-compose.yml logs -f     # View logs
```
