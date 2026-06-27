# FinPilot AI

> **AI-Powered Personal Finance & Smart Payment Platform**

[![CI Pipeline](https://github.com/your-username/finpilot-ai/actions/workflows/ci.yml/badge.svg)](https://github.com/your-username/finpilot-ai/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![Next.js 16](https://img.shields.io/badge/Next.js-16-black.svg)](https://nextjs.org/)
[![PostgreSQL 16](https://img.shields.io/badge/PostgreSQL-16-blue.svg)](https://www.postgresql.org/)

FinPilot AI is a production-grade personal finance management platform that combines intelligent analytics, automated bill payments, and AI-powered financial insights into a single, beautiful interface.

---

## 🏗️ Tech Stack

### Frontend
- **Framework**: Next.js 16 (App Router, Server Components)
- **Language**: TypeScript 5
- **Styling**: Tailwind CSS v4 + shadcn/ui
- **State Management**: TanStack Query v5
- **Animations**: Framer Motion
- **Forms**: React Hook Form + Zod

### Backend
- **Framework**: ASP.NET Core 9
- **Architecture**: Clean Architecture (Domain, Application, Infrastructure, API)
- **ORM**: Entity Framework Core 9
- **Validation**: FluentValidation
- **CQRS**: MediatR
- **Logging**: Serilog

### Infrastructure
- **Database**: PostgreSQL 16
- **Containerization**: Docker + Docker Compose
- **CI/CD**: GitHub Actions
- **API Docs**: Swagger / OpenAPI

---

## 📁 Project Structure

```
finpilot-ai/
├── frontend/         → Next.js 16 application
├── backend/          → ASP.NET Core 9 Clean Architecture
│   └── src/
│       ├── FinPilot.API/            → Web API controllers & middleware
│       ├── FinPilot.Application/    → Business logic & interfaces
│       ├── FinPilot.Domain/         → Entities & domain events
│       ├── FinPilot.Infrastructure/ → EF Core, logging, services
│       └── FinPilot.Shared/         → Cross-cutting constants
├── database/         → SQL scripts & seed data
├── docker/           → Docker configurations
├── docs/             → Architecture & development guides
├── scripts/          → Setup & automation scripts
└── .github/          → CI/CD workflows & templates
```

---

## 🚀 Quick Start

### Prerequisites
- Node.js >= 20.x
- .NET 9 SDK
- Docker (recommended) or PostgreSQL 16

### Using Docker (Recommended)

```bash
docker compose -f docker/docker-compose.yml up -d
```

### Manual Setup

```bash
# Setup script (Windows)
.\scripts\setup.ps1

# Or manually:
cd frontend && npm install && npm run dev
cd backend && dotnet run --project src/FinPilot.API
```

📖 See [docs/setup.md](docs/setup.md) for the full guide.

---

## 📖 Documentation

| Document | Description |
|---|---|
| [Architecture Guide](docs/architecture.md) | System architecture & design decisions |
| [Development Setup](docs/setup.md) | Local development environment setup |
| [Conventions](docs/conventions.md) | Naming, git, coding, and error handling standards |
| [API Reference](docs/api.md) | REST API endpoints & response formats |
| [Folder Structure](docs/folder-structure.md) | Complete project structure explained |

---

## 🗺️ Development Phases

| Phase | Name | Status |
|---|---|---|
| 0 | Project Planning & Design | ✅ Complete |
| 1 | **Project Foundation** | ✅ Complete |
| 2 | Authentication & Authorization | ⬜ Not Started |
| 3 | Finance Core (Wallets, Transactions) | ⬜ Not Started |
| 4 | Dashboard & Analytics | ⬜ Not Started |
| 5 | Bill Payment & Recharge | ⬜ Not Started |
| 6 | AI Integration | ⬜ Not Started |
| 7 | Notifications | ⬜ Not Started |
| 8 | Reports | ⬜ Not Started |
| 9 | Admin Portal | ⬜ Not Started |
| 10 | Deployment | ⬜ Not Started |
| 11 | Optimization | ⬜ Not Started |

---

## 📄 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.

---

<p align="center">
  Built with ❤️ by the FinPilot AI Team
</p>
