# Architecture Guide

## Overview

FinPilot AI follows **Clean Architecture** principles, ensuring separation of concerns, testability, and maintainability.

## System Architecture

```
┌──────────────────────────────────────────────────────────┐
│                     Client Layer                          │
│              Next.js 16 (React, TypeScript)               │
│           Tailwind CSS, shadcn/ui, Framer Motion          │
└──────────────────────┬───────────────────────────────────┘
                       │ HTTP/REST
┌──────────────────────▼───────────────────────────────────┐
│                  Presentation Layer                        │
│               ASP.NET Core 9 Web API                      │
│         Controllers, Middleware, Filters                   │
├──────────────────────────────────────────────────────────┤
│                  Application Layer                         │
│          Use Cases, DTOs, Interfaces                       │
│       MediatR Commands/Queries, FluentValidation           │
├──────────────────────────────────────────────────────────┤
│                   Domain Layer                             │
│         Entities, Value Objects, Domain Events             │
│              Business Rules, Interfaces                    │
├──────────────────────────────────────────────────────────┤
│                Infrastructure Layer                        │
│        EF Core, External APIs, File System                 │
│         PostgreSQL, Serilog, Email Services                │
└──────────────────────┬───────────────────────────────────┘
                       │
┌──────────────────────▼───────────────────────────────────┐
│                   Data Layer                               │
│               PostgreSQL 16                                │
└──────────────────────────────────────────────────────────┘
```

## Dependency Rule

Dependencies ONLY point inward:
- **Domain** has NO dependencies
- **Application** depends on Domain
- **Infrastructure** depends on Application + Domain
- **API** depends on Application + Infrastructure

## Backend Layer Details

### Domain Layer (`FinPilot.Domain`)
- Pure C# classes with no framework dependencies
- Contains: Entities, Value Objects, Domain Events, Enums
- `BaseEntity` and `BaseAuditableEntity` provide common fields

### Application Layer (`FinPilot.Application`)
- Contains business logic orchestration
- Defines interfaces implemented by Infrastructure
- `IRepository<T>` — Generic data access abstraction
- `IUnitOfWork` — Transaction coordination
- `Result<T>` — Explicit success/failure pattern
- Custom exceptions: `AppException`, `NotFoundException`, `ValidationException`

### Infrastructure Layer (`FinPilot.Infrastructure`)
- Implements interfaces defined in Application
- `ApplicationDbContext` — EF Core database context
- Serilog logging configuration
- External service integrations (future phases)

### API Layer (`FinPilot.API`)
- ASP.NET Core Web API controllers
- Global exception middleware
- CORS, Swagger, API versioning configuration
- Health check endpoints

## Frontend Architecture

### Feature-Based Structure
```
src/
├── app/           → Next.js App Router pages
├── components/
│   ├── layout/    → Navbar, Sidebar, Footer, MainLayout
│   ├── ui/        → shadcn/ui primitives (auto-generated)
│   ├── shared/    → Reusable custom components
│   └── providers/ → Context providers (Theme, Query, Toast)
├── hooks/         → Custom React hooks
├── lib/           → Utilities, API client, constants
└── types/         → Global TypeScript types
```

### Key Design Decisions

| Decision | Rationale |
|---|---|
| **App Router** | Server Components, streaming, nested layouts |
| **TanStack Query** | Server state caching with automatic revalidation |
| **Zod + React Hook Form** | Type-safe validation shared between client and server |
| **Framer Motion** | Declarative animations for premium UX |
| **next-themes** | Dark/light mode with SSR hydration safety |
| **Sonner** | Modern toast notifications with rich features |
